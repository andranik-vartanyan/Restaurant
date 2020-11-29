using Restaurant.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Services.Interfaces
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync(int cityId, int skip, int take);
        Task<int> AddRestaurantAsync(RestaurantDto restaurantDto);
        Task<int> AddCityAsync(CityDto cityDto);
    }
}
