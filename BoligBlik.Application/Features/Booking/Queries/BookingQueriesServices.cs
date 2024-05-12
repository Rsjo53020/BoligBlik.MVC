using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoligBlik.Application.DTO.Booking;
using BoligBlik.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using BoligBlik.Domain.Entities;
using BoligBlik.Application.Interfaces.Booking;

namespace BoligBlik.Application.Features.Booking.Queries
{
    public class BookingQueriesServices : IBookingQuerieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingRepo _bookingRepo;
        private readonly IMapper _mapper;

        public BookingQueriesServices(IUnitOfWork unitOfWork, IBookingRepo bookingRepo)
        {
            _unitOfWork = unitOfWork;
            _bookingRepo = bookingRepo;
        }

        //public IEnumerable<Domain.Entities.Booking> Bookings(Domain.Entities.Booking booking)
        //{
        //    return _bookingDbContext.Bookings.AsNoTracking()
        //        .Where(a => /*a.Address.Id == booking.Address.Id &&*/ a.Id != booking.Id).ToList();
        //}
        public async Task<BookingDTO> ReadBooking(BookingDTO bookingDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingDTO>> ReadAllBooking()
        {
            //må jeg det??
            List<BookingDTO> bookingList = new List<BookingDTO>();
            var bookings = await _bookingRepo.ReadAllAsync();

            foreach (var Item in bookings)
            {
                bookingList.Add(_mapper.Map<BookingDTO>(Item));
            }

            return bookingList;
        }
    }
}
