using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Context;
using Restaurant.Data.Domain.Entities;
using Restaurant.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Repositories.Classes
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DatabaseContext _databaseContext;
        public RestaurantRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<City> GetCityByNameAsync(string name)
        {
            return await _databaseContext.Cities.AsNoTracking().SingleOrDefaultAsync(_ => _.Name == name);
        }

        public async Task<RestaurantEntity> GetRestaurantByNameAsync(string name)
        {
            return await _databaseContext.Restaurants.AsNoTracking().SingleOrDefaultAsync(_ => _.Name == name);
        }

        public async Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync(int cityId, int skip, int take)
        {
            return await _databaseContext.Restaurants.Include(_ => _.City).Where(_ => _.CityId == cityId).Skip(skip).Take(take).AsNoTracking().ToListAsync();
        }
    }
}
