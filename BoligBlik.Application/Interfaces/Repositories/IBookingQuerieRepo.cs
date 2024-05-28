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
    public interface IBookingQuerieRepo
    {
        Task<IEnumerable<Booking>> ReadAllAsync();
        Task<Booking> ReadBooking(Guid id);
    }
}
