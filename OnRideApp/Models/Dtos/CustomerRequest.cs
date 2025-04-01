﻿using OnRideApp.Models.MyEnums;

namespace OnRideApp.Models.Dtos
{
    public class CustomerRequest
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
    }
}
