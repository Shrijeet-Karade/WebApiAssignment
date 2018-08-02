﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class HotelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityCode { get; set; }
        public string Address { get; set; }
        public int NumberOfRoomsAvailable { get; set; } 
    }   
}