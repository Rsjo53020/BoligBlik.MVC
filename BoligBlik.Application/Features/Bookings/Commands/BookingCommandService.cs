using System.Data;
using AutoMapper;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.Interfaces.Bookings;
using BoligBlik.Application.Interfaces.Repositories.Bookings.Command;
using BoligBlik.Application.Interfaces.Repositories.UnitOfWork;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.Bookings.Commands
{
    public class BookingCommandService : IBookingCommandService
    {
        //Dependencies
        public readonly IUnitOfWork _unitOfWork;
        private readonly IBookingDomainService _bookingDomainService;
        private readonly IBookingCommandRepo _bookingCommandRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingCommandService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="bookingCommandRepo"></param>
        /// <param name="mapper"></param>
        /// <param name="bookingDomainService"></param>
        /// <param name="logger"></param>
        public BookingCommandService(IUnitOfWork unitOfWork, IBookingCommandRepo bookingCommandRepo, 
            IMapper mapper, IBookingDomainService bookingDomainService, ILogger<BookingCommandService> logger)
        {
            _unitOfWork = unitOfWork;
            _bookingCommandRepo = bookingCommandRepo;
            _mapper = mapper;
            _bookingDomainService = bookingDomainService;
            _logger = logger;
        }

        /// <summary>
        /// Create Booking 
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="Exception"></exception>
        public void CreateBooking(CreateBookingDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var bookingItem = _mapper.Map<BookingItem>(request.Item);

                var createdBooking = Booking.Create(request.StartTime, request.EndTime, bookingItem, request.AddressId,_bookingDomainService);

                _bookingCommandRepo.CreateBooking(createdBooking);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError(ex.Message.ToString());
            }
        }

        /// <summary>
        /// Create Booking
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateBooking(BookingDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var booking = _mapper.Map<Booking>(request);

                _bookingCommandRepo.UpdateBooking(booking);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError(ex.Message.ToString());
                throw new DBConcurrencyException();
            }
        }

        /// <summary>
        /// Delete Booking by BookingId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        public void DeleteBooking(Guid id, byte[] rowVersion)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                _bookingCommandRepo.DeleteBooking(id,rowVersion);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError(ex.Message.ToString());
                throw new DBConcurrencyException();
            }
        }
    }
}
