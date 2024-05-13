using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Exceptions
{
    public class BookingNotFoundException : Exception
    {
        public BookingNotFoundException(Guid id) : base($"Booking with Id: {id} was not found")
        {
        }
        
    }
}
