using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using IsolationLevel = System.Data.IsolationLevel;

namespace BoligBlik.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoligBlikContext _dbContext;
        private IDbContextTransaction? _transaction;


        public UnitOfWork(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public async Task CommitChangesAsync()
        {
            if (_transaction is null)
            {
                return;
            }
            await SaveChangesAsync();
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _transaction?.Dispose();
        }

    }
}

