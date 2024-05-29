﻿using System.Data;
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


        public BookingCommandService(IUnitOfWork unitOfWork, IBookingCommandRepo bookingCommandRepo, IMapper mapper, IBookingDomainService bookingDomainService, ILogger<BookingCommandService> logger)
        {
            _unitOfWork = unitOfWork;
            _bookingCommandRepo = bookingCommandRepo;
            _mapper = mapper;
            _bookingDomainService = bookingDomainService;
            _logger = logger;
        }

        //public void CreateBooking(CreateBookingDTO request)
        //{
        //    try
        //    {
        //        _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

        //        //var booking = _mapper.Map<Booking>(request);
        //        var booking = Booking.Create(request.StartTime, request.EndTime, request.Item, _bookingDomainService);

        //        booking.IsOverlapping(_bookingDomainService);
        //        var isOverlapping = _bookingDomainService.IsBookingOverlapping(booking);
        //        if (!isOverlapping)
        //        {
        //            _bookingCommandRepo.CreateBooking(booking);
        //            _unitOfWork.Commit();
        //        }
        //        else
        //        {
        //            _unitOfWork.Rollback();
        //            throw new Exception("The booking overlaps with existing bookings.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _unitOfWork.Rollback();
        //        _logger.LogError("Could not create booking", ex);
        //        throw new Exception("Error occurred while creating booking", ex);
        //    }
        //}


        public void CreateBooking(CreateBookingDTO request)
        {
            throw new NotImplementedException();
        }

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
                _logger.LogError("Could not update booking", ex);
                throw;
            }
        }


        public void DeleteBooking(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                _bookingCommandRepo.DeleteBooking(id);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("Could not delete booking", ex);
                throw;
            }
        }
    }
}
