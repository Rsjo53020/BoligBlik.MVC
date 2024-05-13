using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories
{
    public class BookingCommandRepo : IBookingCommandRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<Booking> _logger;

        public BookingCommandRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
            //_dbSet = _dbContext.Set<Booking>();
        }
        public void Create(Booking booking)
        {
            try
            {
                _dbContext.AddAsync(booking);
                _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in CreateAsync in Booking: " + ex.Message);
            }

        }


        public void UpdateBooking(Booking booking)
        {
            try
            {
                _dbContext.Update(booking);
                _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in CreateAsync in Booking: " + ex.Message);
            }
        }

        public void DeleteBooking(Booking booking)
        {
            try
            {
                _dbContext.Remove(booking);
                _dbContext.SaveChangesAsync();
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in CreateAsync in Booking: " + ex.Message);
            }
        }
    }
}
