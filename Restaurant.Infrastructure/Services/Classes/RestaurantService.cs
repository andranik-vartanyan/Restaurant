using AutoMapper;
using Restaurant.Data.Domain.Entities;
using Restaurant.Data.Repositories.Interfaces;
using Restaurant.Infrastructure.Services.Extensions;
using Restaurant.Infrastructure.Services.Interfaces;
using Restaurant.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Services.Classes
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IGenericRepository<RestaurantEntity> _restaurantGenericRepository;
        private readonly IGenericRepository<City> _cityGenericRepository;
        private readonly IMapper _mapper;
        public RestaurantService(IRestaurantRepository restaurantRepository,
        IGenericRepository<RestaurantEntity> restaurantGenericRepository,
        IGenericRepository<City> cityGenericRepository,
        IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _restaurantGenericRepository = restaurantGenericRepository;
            _cityGenericRepository = cityGenericRepository;
            _mapper = mapper;
        }

        public async Task<int> AddCityAsync(CityDto cityDto)
        {
            if (await _restaurantRepository.GetCityByNameAsync(cityDto.Name) != null)
                return 0;

            Task task = _cityGenericRepository.AddAsync(_mapper.Map<CityDto, City>(cityDto));
            await task.Logger();
            if (task.IsFaulted)
                return -1;

            return 1;
        }

        public async Task<int> AddRestaurantAsync(RestaurantDto restaurantDto)
        {
            if (await _restaurantRepository.GetRestaurantByNameAsync(restaurantDto.Name) != null)
                return 0;

            Task task = _restaurantGenericRepository.AddAsync(_mapper.Map<RestaurantDto, RestaurantEntity>(restaurantDto));
            await task;
            if (task.IsFaulted)
                return -1;

            return 1;
        }

        public async Task<IEnumerable<RestaurantDto>> GetRestaurantsAsync(int cityId, int skip, int take)
        {
            return _mapper.Map<IEnumerable<RestaurantEntity>, IEnumerable<RestaurantDto>>(
                await _restaurantRepository.GetRestaurantsAsync(cityId, skip, take));
        }
    }
}
