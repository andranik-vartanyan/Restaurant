using Restaurant.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Data.Repositories.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<RestaurantEntity>> GetRestaurantsAsync(int cityId, int skip, int take);
        Task<RestaurantEntity> GetRestaurantByNameAsync(string name);
        Task<City> GetCityByNameAsync(string name);
    }
}
