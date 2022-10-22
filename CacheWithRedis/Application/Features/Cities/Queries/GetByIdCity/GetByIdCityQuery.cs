using Application.Features.Cities.Dtos;
using Application.Services;
using AutoMapper;
using MediatR;
using Persistence.Entities;

namespace Application.Features.Cities.Queries.GetByIdCity;

public class GetByIdCityQuery : IRequest<CityDto>
{
    public int Id { get; set; }
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
            City city = await _cityRepository.GetAsync(c => c.Id == request.Id);

            CityDto mappetCity = _mapper.Map<CityDto>(city);

            return mappetCity;
        }
    }
}
