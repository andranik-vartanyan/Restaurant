using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Infrastructure.Services.Interfaces;
using Restaurant.Shared.Dto;
using Restaurant.Shared.Models;
using Restaurant.Shared.ResponseMessages;

namespace Restaurant.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;
        public RestaurantController(IRestaurantService restaurantService,
            IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        [HttpGet("get-restaurants/{cityId}/{skip}/{take}")]
        public async Task<IActionResult> GetRestaurants(int cityId, int skip, int take)
        {
            return Ok(_mapper.Map<IEnumerable<RestaurantDto>,
                IEnumerable<RestaurantModel>>(await _restaurantService
                .GetRestaurantsAsync(cityId, skip, take)));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] RestaurantModel model)
        {
            int status = await _restaurantService
                .AddRestaurantAsync(_mapper.Map<RestaurantModel, RestaurantDto>(model));
            switch(status)
            {
                case -1: Response.StatusCode = 500; return BadRequest(Messages.InternalError);
                case 0: return BadRequest(Messages.RestaurantExistsError);
            }
            return Ok(Messages.RestaurantSuccessfulAdded);
        }

        [HttpPost("add-city")]
        public async Task<IActionResult> AddCity([FromBody] CityModel model)
        {
            int status = await _restaurantService
                .AddCityAsync(_mapper.Map<CityModel, CityDto>(model));
            switch (status)
            {
                case -1: Response.StatusCode = 500; return BadRequest(Messages.InternalError);
                case 0: return BadRequest(Messages.CityExistsError);
            }
            return Ok(Messages.CitySuccessfulAdded);
        }
    }
}
