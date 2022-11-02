﻿using Domain.Abstractions.RequestModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Services
{
    public interface IBookingService : IService<BookingRequest, Booking>
    {
    }
}
