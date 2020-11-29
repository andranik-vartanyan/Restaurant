using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Data.Context;
using Restaurant.Data.Domain.Entities;
using Restaurant.Data.Repositories.Classes;
using Restaurant.Data.Repositories.Interfaces;
using Restaurant.Infrastructure.Services.Classes;
using Restaurant.Infrastructure.Services.Interfaces;
using Restaurant.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Web
{
    public partial class Startup
    {
        private void AddDb(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("restaurant")));
        }
        private void DI(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDI(configuration);
        }
    }
}
