using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Infrastructure.Extensions;
using BoligBlik.Infrastructure.Services.Addresses;
using BoligBlik.Persistence.Repositories.BoardMembers;
using BoligBlik.Persistence.Repositories.Bookings;
using BoligBlik.WebAPI;
using BoligBlik.WebAPI.Controllers;
using System.Reflection;

namespace Boligblik.Test
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(BoardMember).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(BoardMemberCommandService).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(AddressValidationInf).Assembly;
        protected static readonly Assembly PersistanceAssembly = typeof(BoardMemberCommandRepo).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(BoardMemberController).Assembly;
    }
}
