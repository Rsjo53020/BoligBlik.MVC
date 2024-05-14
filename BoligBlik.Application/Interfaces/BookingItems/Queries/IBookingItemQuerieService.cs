﻿using BoligBlik.Application.DTO.BoardMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;

namespace BoligBlik.Application.Interfaces.BookingItems.Queries
{
    public interface IBookingItemQuerieService
    {
        public Task<BookingItemDTO> ReadBookingItemAsync(string title);
        public Task<IEnumerable<BookingItemDTO>> ReadAllBookingItemsAsync();
    }
}
