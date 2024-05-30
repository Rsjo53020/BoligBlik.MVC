using BoligBlik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Common.Interfaces
{
    /// <summary>
    /// Interface for bookingDomainService
    /// </summary>
    public interface IBookingDomainService
    {
       public bool IsBookingOverlapping(Booking booking);
       public DateTime NowTime();
    }
}
