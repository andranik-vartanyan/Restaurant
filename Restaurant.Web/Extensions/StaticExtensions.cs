using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Data.Domain.Entities;
using Restaurant.Data.Repositories.Classes;
using Restaurant.Data.Repositories.Interfaces;
using Restaurant.Infrastructure.Services.Classes;
using Restaurant.Infrastructure.Services.Interfaces;
using Restaurant.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Web.Extensions
{
    public static class StaticExtensions
    {
        public static void AddDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IGenericRepository<RestaurantEntity>, GenericRepository<RestaurantEntity>>();
            services.AddTransient<IGenericRepository<City>, GenericRepository<City>>();
            services.AddTransient<IRestaurantRepository, RestaurantRepository>();
            services.AddTransient<IRestaurantService, RestaurantService>();
            services.AddAutoMapper(typeof(Profiles));
        }
    }
}
