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

        public void CreateBooking(CreateBookingDTO createBookingDTO/*, UserDTO userDTO, ItemDTO itemDTO ,PaymentDTO paymentDTO*/)
        {
            //try
            //{
            //    _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
            //    var UserId = _userQuerieRepo.ReadUser(userDTO.EmailAddress);
            //    var AddressId = _addressQuerieRepo.WriteAddress(userDTO.Id);
            //    var ItemId = _itemQuerieRepo.ReadItem(itemDTO.Id);
            //    var paymentId = _paymentQuerieRepo.WriteItem(itemDTO.Id);
            //    var UserId = "ronnisjorgensen@gmail.com";
            //    var AddressId = Guid.NewGuid();
            //    var ItemId = Guid.NewGuid();
            //    var paymentId = Guid.NewGuid();
            //    var bookingDates = new BookingDates(createBookingDTO.CreationDate, createBookingDTO.StartTime, createBookingDTO.EndTime);
            //    var booking = new Domain.Entities.Booking(Guid.NewGuid(), bookingDates, ItemId, paymentId, AddressId, UserId, createBookingDTO.Approved, _bookingDomainService, createBookingDTO.RowVersion);
            //    _bookingRepo.Create(booking);

            //    _unitOfWork.CommitChangesAsync();
            //}
            //catch (Exception e)
            //{
            //    _unitOfWork.Rollback();
            //    throw;
            //}
        }

        public void UpdateBooking(UpdateBookingDTO request)
        {

            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var bookings = _mapper.Map<Booking>(request);

                _bookingCommandRepo.UpdateBooking(bookings);

                _unitOfWork.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("could not update booking", ex);
            }
        }

        public void DeleteBooking(DeleteBookingDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var bookings = _mapper.Map<Booking>(request);

                _bookingCommandRepo.DeleteBooking(bookings);

                _unitOfWork.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("could not delete booking", ex);
            }
        }
    }
}
