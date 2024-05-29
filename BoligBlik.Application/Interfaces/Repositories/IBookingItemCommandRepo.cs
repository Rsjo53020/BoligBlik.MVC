using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IBookingItemCommandRepo
    {
        public void CreateBookingItem(BookingItem request);
        public void UpdateBookingItem(BookingItem request);
        public void DeleteBookingItem(Guid id);
    }
}
