using Domain.Abstractions.RequestModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            this.CreateMap<Booking, BookingRequest>().ReverseMap()
                .ForAllMembers(x => x.Condition((src, dest, srcValue) => srcValue != null));
        }
    }
}