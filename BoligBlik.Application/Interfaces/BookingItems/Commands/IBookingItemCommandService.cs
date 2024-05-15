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
        public void UpdateBookingItem(UpdateBookingItemDTO request);
        public void DeleteBookingItem(DeleteBookingItemDTO request);
    }
}
