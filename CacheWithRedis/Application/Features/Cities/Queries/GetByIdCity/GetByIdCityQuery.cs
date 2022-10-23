using Application.Features.Cities.Dtos;
using Application.Services;
using AutoMapper;
using Core.Caching;
using MediatR;
using Persistence.Entities;

namespace Application.Features.Cities.Queries.GetByIdCity;

public class GetByIdCityQuery : IRequest<CityDto>, ICachableRequest
{
    public int Id { get; set; }

    public bool BypassCache => false;

    public string CacheKey => $"{this.GetType().Name}&id={this.Id}";

    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(10);

    public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQuery, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetByIdCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(GetByIdCityQuery request, CancellationToken cancellationToken)
        {
            City? city = await _cityRepository.GetAsync(c => c.Id == request.Id);

            CityDto mappetCity = _mapper.Map<CityDto>(city);

            return mappetCity;
        }
    }
}
