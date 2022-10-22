using Application.Features.Countries.Models;
using Application.Services;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Application.Features.Countries.Queries.GetListCountry;

public class GetListCountryQuery : IRequest<CountryListModel>
{
    public PageRequest PageRequest { get; set; }
    public class GetListCountryQueryHandler : IRequestHandler<GetListCountryQuery, CountryListModel>
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public GetListCountryQueryHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<CountryListModel> Handle(GetListCountryQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Country> countries = await _countryRepository.GetListAsync(include: x => x.Include(c => c.Cities),
                                                                                 index: request.PageRequest.Page,
                                                                                 size: request.PageRequest.PageSize,
                                                                                 enableTracking: false,
                                                                                 orderBy: g => g.OrderBy(g => g.Id));

            CountryListModel mappedCountryListModel = _mapper.Map<CountryListModel>(countries);

            return mappedCountryListModel;
        }
    }
}
