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
        void Create(Domain.Entities.Booking booking);
        Task<IEnumerable<Domain.Entities.Booking>> ReadAllAsync();
        
        void UpdateBooking(Domain.Entities.Booking booking);
        void DeleteBooking(Domain.Entities.Booking booking);
    }
}
