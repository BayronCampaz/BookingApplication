﻿
namespace Domain.Abstractions.RequestModels
{
    public class RestaurantRequest
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
    }
}
