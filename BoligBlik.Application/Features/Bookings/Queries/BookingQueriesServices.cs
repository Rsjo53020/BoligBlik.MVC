using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using BoligBlik.Domain.Entities;
using BoligBlik.Application.Interfaces.Bookings;
using System.Threading;
using BoligBlik.Domain.Exceptions;

namespace BoligBlik.Application.Features.Bookings.Queries
{
    public class BookingQueriesServices : IBookingQuerieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingQuerieRepo _bookingRepo;
        private readonly IMapper _mapper;

        public BookingQueriesServices(IUnitOfWork unitOfWork, IBookingQuerieRepo bookingRepo)
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
            var booking = await _bookingRepo.ReadBooking(bookingDto.Id);
            if (booking is null)
            {
                throw new BookingNotFoundException(bookingDto.Id);
            }
            var resultat = _mapper.Map<BookingDTO>(booking);
            return resultat;
        }

        public async Task<IEnumerable<BookingDTO>> ReadAllBooking()
        {
            //må jeg det??
            List<BookingDTO> bookingList = new List<BookingDTO>();
            var bookings = await _bookingRepo.ReadAllAsync();

            foreach (var booking in bookings)
            {
                bookingList.Add(_mapper.Map<BookingDTO>(booking));
            }

            return bookingList;
        }
    }
}
