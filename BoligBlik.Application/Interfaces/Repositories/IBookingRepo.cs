using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IBookingRepo
    {
        Task CreateAsync(Booking booking);
        Task<IEnumerable<Booking>> ReadAllAsync();
        
        void UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);
    }
}
