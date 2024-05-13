using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Infrastructure.Extensions;
using BoligBlik.Persistence.Repositories.Bookings;
using BoligBlik.WebAPI;
using System.Reflection;

namespace Boligblik.Test
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(IBookingQuerieRepo).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(ServiceCollectionExtensions).Assembly;
        protected static readonly Assembly PersistanceAssembly = typeof(BookingDomainService).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
    }
}
