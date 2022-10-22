using Application.Features.Cities.Dtos;
using Application.Features.Cities.Models;
using AutoMapper;
using Core.Paging;
using Persistence.Entities;

namespace Application.Features.Cities.Profiles;

public class CityMappingProfile : Profile
{
	public CityMappingProfile()
	{
		CreateMap<City, CityDto>().ReverseMap();

		CreateMap<IPaginate<City>, CityListModel>().ReverseMap();
	}
}
