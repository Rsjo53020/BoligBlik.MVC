using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Infrastructure.Extensions;
using BoligBlik.Persistence.Services;
using BoligBlik.WebAPI;
using System.Reflection;

namespace Boligblik.Test
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(IBookingRepo).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(IServiceCollectionExtensions).Assembly;
        protected static readonly Assembly PersistanceAssembly = typeof(BookingDomainService).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(Program).Assembly;
    }
}
