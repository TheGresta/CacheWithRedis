using Application.Features.Cities.Models;
using Application.Services;
using AutoMapper;
using Core.Caching;
using Core.Paging;
using Core.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Application.Features.Cities.Queries.GetListCity;

public class GetListCityQuery : IRequest<CityListModel>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache => false;

    public string CacheKey => $"{this.GetType().Name}&pagesize={this.PageRequest.Page}&page{this.PageRequest.PageSize}";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(20);

    public class GetListCityQueryHandler : IRequestHandler<GetListCityQuery, CityListModel>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetListCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityListModel> Handle(GetListCityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<City> cities = await _cityRepository.GetListAsync(include: x => x.Include(c => c.Country),
                                                                        index: request.PageRequest.Page,
                                                                        size: request.PageRequest.PageSize,
                                                                        enableTracking: false,
                                                                        orderBy: g => g.OrderBy(g => g.Id));

            CityListModel mappedCityListModel = _mapper.Map<CityListModel>(cities);

            return mappedCityListModel;
        }
    }
}
