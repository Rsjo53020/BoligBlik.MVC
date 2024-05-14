﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Item;

namespace BoligBlik.Application.DTO.Bookings
{
    public class BookingDTO
    {
        [Required]
        public Guid Id { get; set; }
        public DateOnly creationDate { get; set; }
        [Required]
        public  DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public bool Approved { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        public IEnumerable<ItemDTO> Item { get; set; }

        [Required]
        public Guid AddressId { get; set; }
    }

    
}