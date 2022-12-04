﻿using System;
using Core;

namespace Entities.DTOs
{
    public class RentalDetailDto : IDto
    {
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}