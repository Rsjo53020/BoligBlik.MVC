using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using IsolationLevel = System.Data.IsolationLevel;

namespace BoligBlik.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BoligBlikContext _db;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BoligBlikContext db)
        {
            _db = db;
        }
        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            _transaction = _db.Database.CurrentTransaction ?? _db.Database.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Commit();
            _transaction.Dispose();
        }




        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
            _db.Dispose();
        }

    }
}

