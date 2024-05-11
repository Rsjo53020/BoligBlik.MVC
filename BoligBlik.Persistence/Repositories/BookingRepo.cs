using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BoligBlik.Persistence.Repositories
{
    public class BookingRepo : IBookingRepo
    {
        private readonly BookingDbContext _dbContext;
        private readonly DbSet<Booking> _dbSet;
        private readonly ILogger<Booking> _logger;

        public BookingRepo(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Booking>();
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

        public Task<IEnumerable<Booking>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> ReadAllAsync(IEnumerable<Booking> bookings)
        {
            //Enumerable<Booking> bookings = new List<Booking>();
            try
            {
                //var result = _dbContext.Bookings.Where(a => bookings.Contains(a.Address)).ToList();
                //return result.Any() ?? Enumerable.Empty<Booking>();
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in ReadAll in Booking: " + ex.Message);
            }
            throw new NotImplementedException();
        }

        public void UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
