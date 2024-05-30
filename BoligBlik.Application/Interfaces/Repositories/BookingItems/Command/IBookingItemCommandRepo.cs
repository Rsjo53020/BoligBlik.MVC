using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Repositories.BookingItems.Command
{
    public interface IBookingItemCommandRepo
    {
        void CreateBookingItem(BookingItem request);
        void UpdateBookingItem(BookingItem request);
        void DeleteBookingItem(Guid id, byte[] rowVersion);
    }
}
