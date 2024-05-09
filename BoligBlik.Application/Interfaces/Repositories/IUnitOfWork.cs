using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Repositories
{
    // Kilde:https://medium.com/@edin.sahbaz/implementing-the-unit-of-work-pattern-in-clean-architecture-with-net-core-53efb7f9d4d
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepo Bookings { get; }

        void BeginTransaction();
        Task CommitChangesAsync(CancellationToken cancellationToken);
        void Rollback();

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
