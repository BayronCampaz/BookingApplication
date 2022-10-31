﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Booking
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Client Client { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}