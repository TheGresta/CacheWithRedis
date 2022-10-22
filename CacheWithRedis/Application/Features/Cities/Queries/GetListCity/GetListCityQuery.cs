﻿using Application.Features.Cities.Models;
using Application.Services;
using AutoMapper;
using Core.Paging;
using Core.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Application.Features.Cities.Queries.GetListCity;

public class GetListCityQuery : IRequest<CityListModel>
{
    public PageRequest PageRequest { get; set; }
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
