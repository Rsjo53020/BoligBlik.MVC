using BoligBlik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Common.Interfaces
{
    public interface IBookingDomainService
    {
       public bool IsBookingOverlapping(Booking booking);

       //IEnumerable<Booking> OtherBookings(Booking booking);

       public DateTime NowTime();
    }
}
