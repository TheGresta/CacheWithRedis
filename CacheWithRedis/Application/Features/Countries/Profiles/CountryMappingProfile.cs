using Application.Features.Cities.Dtos;
using Application.Features.Countries.Dtos;
using Application.Features.Countries.Models;
using AutoMapper;
using Core.Paging;
using Persistence.Entities;

namespace Application.Features.Countries.Profiles;

public class CountryMappingProfile : Profile
{
	public CountryMappingProfile()
	{
		CreateMap<CountryDto, Country>()
			.ReverseMap();

		CreateMap<City, CountryCityDto>()
			.ForMember(c => c.Id, opt => opt.MapFrom(src => src.Id))
			.ForMember(c => c.Name, opt => opt.MapFrom(src => src.Name))
            .ReverseMap();

		CreateMap<IPaginate<Country>, CountryListModel>()
			.ReverseMap();
	}
}
