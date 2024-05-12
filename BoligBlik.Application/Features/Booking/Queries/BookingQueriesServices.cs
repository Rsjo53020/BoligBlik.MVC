using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using BoligBlik.Domain.Entities;
using BoligBlik.Application.Interfaces.Booking;

namespace BoligBlik.Application.Features.Booking.Queries
{
    public class BookingQueriesServices : IBookingQuerieService
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly BookingDbContext _bookingDbContext;

        public BookingQueriesServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public IEnumerable<Domain.Entities.Booking> Bookings(Domain.Entities.Booking booking)
        //{
        //    return _bookingDbContext.Bookings.AsNoTracking()
        //        .Where(a => /*a.Address.Id == booking.Address.Id &&*/ a.Id != booking.Id).ToList();
        //}
    }
}
