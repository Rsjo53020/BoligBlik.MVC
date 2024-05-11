using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace BoligBlik.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBookingRepo Bookings { get; }
        private readonly BookingDbContext _dbContext;
        private IDbContextTransaction? _beginTransaction;


        public UnitOfWork(BookingDbContext dbContext, IBookingRepo bookings)
        {
            _dbContext = dbContext;
            Bookings = bookings;
        }

        public void Rollback()
        {
            _beginTransaction.Rollback();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);

        }

        public void BeginTransaction()
        {
            _beginTransaction = _dbContext.Database.BeginTransaction();
        }

        public async Task CommitChangesAsync(CancellationToken cancellationToken)
        {
            if (_beginTransaction is null)
            {
                return;
            }

            await _beginTransaction.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}

