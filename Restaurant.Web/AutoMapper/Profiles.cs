using AutoMapper;
using Restaurant.Data.Domain.Entities;
using Restaurant.Shared.Dto;
using Restaurant.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Web.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<RestaurantModel, RestaurantDto>().ReverseMap();
            CreateMap<RestaurantDto, RestaurantEntity>().ReverseMap();
            CreateMap<CityModel, CityDto>().ReverseMap();
            CreateMap<CityDto, City>().ReverseMap();
        }
    }
}
