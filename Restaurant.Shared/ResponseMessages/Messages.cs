using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Shared.ResponseMessages
{
    public class Messages
    {
        public const string InternalError = "Internal server error.";
        public const string RestaurantExistsError = "This restaurant already exists.";
        public const string RestaurantSuccessfulAdded = "This restaurant successful added.";
        public const string CityExistsError = "This city already exists.";
        public const string CitySuccessfulAdded = "This city successful added.";
    }
}
