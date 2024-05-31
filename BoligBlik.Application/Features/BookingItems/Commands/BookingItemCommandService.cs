using AutoMapper;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.Interfaces.BookingItems.Commands;
using BoligBlik.Application.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.BookingItems.Commands
{
    internal class BookingItemCommandService : IBookingItemCommandService
    {
        // Dependencies
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IBookingItemCommandRepo _bookingItemRepo;
        private readonly ILogger<IBookingItemCommandService> _logger;

        //Constructor
        public BookingItemCommandService(IUnitOfWork uow, IMapper mapper, IBookingItemCommandRepo bookingItemRepo)
        {
            _uow = uow;
            _mapper = mapper;
            _bookingItemRepo = bookingItemRepo;
        }

        //Create a booking item
        public void CreateBookingItem(CreateBookingItemDTO request)
        {
            try
            {
                _uow.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var bookingItem = _mapper.Map<Domain.Entities.BookingItem>(request);
                _bookingItemRepo.CreateBookingItem(bookingItem);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error creating booking item with request: {@request}, Exception: {ex}", request, ex);
            }
        }

        //Update a booking item
        public void UpdateBookingItem(BookingItemDTO request)
        {
            try
            {
                _uow.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var bookingItem = _mapper.Map<Domain.Entities.BookingItem>(request);
                _bookingItemRepo.UpdateBookingItem(bookingItem);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error updating booking item with request: {@request}, Exception: {ex}", request, ex);
            }
        }

        //Delete a booking item
        public void DeleteBookingItem(BookingItemDTO request)
        {
            try
            {
                _uow.BeginTransaction(System.Data.IsolationLevel.Serializable);

                var bookingItem = _mapper.Map<Domain.Entities.BookingItem>(request);
                _bookingItemRepo.DeleteBookingItem(bookingItem);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error deleting booking item with request: {@request}, Exception: {ex}", request, ex);
            }
        }
    }
}