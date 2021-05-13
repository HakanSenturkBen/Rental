﻿using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class RentalDto : IDto
    {
        public int RentalId { get; set; }
        public string BrandName { get; set; }
        public string CustomerName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
