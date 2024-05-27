using System.Data;
using AutoMapper;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.Interfaces.Bookings;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.Bookings.Commands
{
    public class BookingCommandService : IBookingCommandService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IBookingDomainService _bookingDomainService;
        private readonly IBookingCommandRepo _bookingCommandRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingCommandService> _logger;

        private readonly IUserQuerieRepo _userQuerieRepo;
        private readonly IAddressQuerieRepo _addressQuerieRepo;
        private readonly IBookingItemQuerieRepo _itemQuerieRepo;
        //private readonly IPaymentQuerieRepo _paymentQuerieRepo;


        public BookingCommandService(IUnitOfWork unitOfWork, IBookingDomainService bookingDomainService, IBookingCommandRepo bookingCommandRepo, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _bookingDomainService = bookingDomainService;
            _bookingCommandRepo = bookingCommandRepo;
            _mapper = mapper;
        }

        public void CreateBooking(CreateBookingDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var booking = _mapper.Map<Booking>(request);

                _bookingCommandRepo.CreateBooking(booking);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();

                _logger.LogError("Could not create booking", ex);

                throw new Exception("Error occurred while creating booking", ex);
            }
        }


        public void UpdateBooking(BookingDTO request)
        {

            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var bookings = _mapper.Map<Booking>(request);

                _bookingCommandRepo.UpdateBooking(bookings);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("could not update booking", ex);
            }
        }

        public void DeleteBooking(BookingDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var bookings = _mapper.Map<Booking>(request);

                _bookingCommandRepo.DeleteBooking(bookings);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("could not delete booking", ex);
            }
        }
    }
}
