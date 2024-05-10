using System.Data;
using System.Net;
using BoligBlik.Application.Dto.Booking;
using BoligBlik.Application.Interfaces;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Value;

namespace BoligBlik.Application.Features.Booking.Commands
{
    public class BookingCommandService : IBookingCommandService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IBookingDomainService _bookingDomainService;
        private readonly IBookingRepo _bookingRepo;

        //private readonly IAddressDominService _addressDominService;

        public BookingCommandService(IUnitOfWork unitOfWork, IBookingDomainService bookingDomainService, IBookingRepo bookingRepo)
        {
            _unitOfWork = unitOfWork;
            _bookingDomainService = bookingDomainService;
            _bookingRepo = bookingRepo;
        }

        public void CreateBooking(CreateBookingDto createBookingDto)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var bookingDates = new BookingDates(createBookingDto.CreationDate, createBookingDto.StartTime, createBookingDto.EndTime);
                var booking = new Domain.Entities.Booking(bookingDates, createBookingDto.Approved, _bookingDomainService);
                _bookingRepo.Create(booking);

                _unitOfWork.CommitChangesAsync();
            }
            catch (Exception e)
            {
                _unitOfWork.Rollback();
                throw;
            }

        }

        public void UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(DeleteBookingDto deleteBookingDto)
        {
            throw new NotImplementedException();
        }
    }
}
