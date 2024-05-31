using AutoMapper;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.Interfaces.BookingItems.Commands;
using BoligBlik.Application.Interfaces.Repositories.BookingItems.Command;
using BoligBlik.Application.Interfaces.Repositories.UnitOfWork;
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uow"></param>
        /// <param name="mapper"></param>
        /// <param name="bookingItemRepo"></param>
        public BookingItemCommandService(IUnitOfWork uow, IMapper mapper, IBookingItemCommandRepo bookingItemRepo)
        {
            _uow = uow;
            _mapper = mapper;
            _bookingItemRepo = bookingItemRepo;
        }

        /// <summary>
        /// Create a booking item
        /// </summary>
        /// <param name="request"></param>
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
                _logger.LogError("Error creating booking item", ex.Message);
            }
        }

        /// <summary>
        /// Update a booking item
        /// </summary>
        /// <param name="request"></param>
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
                _logger.LogError("Error updating booking", ex.Message);
            }
        }

        /// <summary>
        /// Delete a booking item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        public void DeleteBookingItem(Guid id, Byte[] rowVersion)
        {
            try
            {
                _uow.BeginTransaction(System.Data.IsolationLevel.Serializable);

                _bookingItemRepo.DeleteBookingItem(id, rowVersion);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error deleting booking item", ex.Message);
            }
        }
    }
}