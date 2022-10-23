using Application.Features.Cities.Dtos;
using Application.Services;
using AutoMapper;
using Core.Caching;
using MediatR;
using Persistence.Entities;

namespace Application.Features.Cities.Commands.DeleteCity;

public class DeleteCityCommand : IRequest<CityDto>, ICacheRemoverRequest
{
    public int Id { get; set; }

    public bool BypassCache => true;

    public string CacheKey => "";

    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public DeleteCityCommandHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDto> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            City? city = await _cityRepository.GetAsync(c => c.Id == request.Id);
            City deletedCity = await _cityRepository.DeleteAsync(city);

            CityDto mappetCity = _mapper.Map<CityDto>(deletedCity);

            return mappetCity;
        }
    }
}
