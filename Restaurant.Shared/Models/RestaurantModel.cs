using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Shared.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public CityModel City { get; set; }
    }
}
