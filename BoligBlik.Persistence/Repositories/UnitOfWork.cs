using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Transactions;
using IsolationLevel = System.Data.IsolationLevel;

namespace BoligBlik.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookingDbContext _dbContext;
        private IDbContextTransaction? _beginTransaction;


        public UnitOfWork(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Rollback()
        {
            _beginTransaction.Rollback();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _beginTransaction = _dbContext.Database.BeginTransaction();
        }

        public async Task CommitChangesAsync()
        {
            if (_beginTransaction is null)
            {
                return;
            }

            await _beginTransaction.CommitAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}

