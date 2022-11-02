using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            this.CreateMap<Restaurant, RestaurantRequest>().ReverseMap();
        }
    }
}
