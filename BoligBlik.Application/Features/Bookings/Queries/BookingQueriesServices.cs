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
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.Bookings.Queries
{
    public class BookingQueriesServices : IBookingQuerieService
    {
        //Dependencies
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookingQuerieRepo _bookingRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingQueriesServices> _logger;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="bookingRepo"></param>
        /// <param name="mapper"></param>
        public BookingQueriesServices(IUnitOfWork unitOfWork,
            IBookingQuerieRepo bookingRepo, IMapper mapper, ILogger<BookingQueriesServices> logger)
        {
            _unitOfWork = unitOfWork;
            _bookingRepo = bookingRepo;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Read booking by BookingId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BookingNotFoundException"></exception>
        public async Task<BookingDTO> ReadBookingAsync(Guid id)
        {
            try
            {
                var booking = await _bookingRepo.ReadBooking(id);
                var BookingDTO = _mapper.Map<BookingDTO>(booking);
                return BookingDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        /// <summary>
        /// Read All Bookings
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookingDTO>> ReadAllBookingAsync()
        {
            try
            {
                var bookings = await _bookingRepo.ReadAllAsync();
                var bookingDTO = _mapper.Map<IEnumerable<BookingDTO>>(bookings);
                return bookingDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
