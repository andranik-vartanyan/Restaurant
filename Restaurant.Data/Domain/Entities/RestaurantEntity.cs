using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Data.Domain.Entities
{
    public class RestaurantEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
