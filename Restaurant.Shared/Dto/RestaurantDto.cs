using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Shared.Dto
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public CityDto City { get; set; }
    }
}
