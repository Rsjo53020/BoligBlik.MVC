using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;

namespace BoligBlik.Application.Interfaces.BookingItems.Commands
{
    public interface IBookingItemCommandService
    {
        public void CreateBookingItem(CreateBookingItemDTO request);
        public void UpdateBookingItem(BookingItemDTO request);
        public void DeleteBookingItem(BookingItemDTO request);
    }
}
