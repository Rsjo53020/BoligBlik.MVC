using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Persistence.Services
{
    public class BookingDomainService : IBookingDomainService
    {
        public IEnumerable<Booking> OtherBookings(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
