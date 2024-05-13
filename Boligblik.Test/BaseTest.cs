using BoligBlik.Application.Features.User.Commands;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Infrastructure.Extensions;
using BoligBlik.Infrastructure.Services.Message;
using BoligBlik.Persistence.Repositories.Commands;
using BoligBlik.Persistence.Services;
using BoligBlik.WebAPI;
using BoligBlik.WebAPI.Controllers;
using System.Reflection;

namespace Boligblik.Test
{
    public abstract class BaseTest
    {
        protected static readonly Assembly DomainAssembly = typeof(User).Assembly;
        protected static readonly Assembly ApplicationAssembly = typeof(UserCommandService).Assembly;
        protected static readonly Assembly InfrastructureAssembly = typeof(MessageService).Assembly;
        protected static readonly Assembly PersistanceAssembly = typeof(UserCommandRepo).Assembly;
        protected static readonly Assembly PresentationAssembly = typeof(UserController).Assembly;
    }
}
