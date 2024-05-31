using System.Data;
using AutoMapper;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Repositories.UnitOfWork;
using BoligBlik.Application.Interfaces.Repositories.Users.Command;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.Users.Commands
{
    public class UserCommandService : IUserCommandService
    {
        // Dependencies
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IUserCommandRepo _userRepo;
        private readonly ILogger<IUserCommandService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserCommandService(IUnitOfWork uow, IMapper mapper, IUserCommandRepo userCommandRepo)
        {
            _uow = uow;
            _mapper = mapper;
            _userRepo = userCommandRepo;
        }

        /// <summary>
        /// this method creates a user using Unit of Work pattern
        /// </summary>
        public void CreateUser(CreateUserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);

                var user = _mapper.Map<User>(request);
                _userRepo.CreateUser(user);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error creating user", ex.Message);

            }
        }
        /// <summary>
        /// this method updates a user using Unit of Work pattern
        /// </summary>
        public void UpdateUser(UserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                var user = _mapper.Map<User>(request);
                _userRepo.UpdateUser(user);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error updating user with request", ex.Message);
            }
        }
        /// <summary>
        /// this method Deletes a user using Unit of Work pattern
        /// </summary>
        public void DeleteUser(Guid id, Byte[] rowVersion)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                _userRepo.DeleteUser(id, rowVersion);
                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error deleting user with request", ex.Message);
            }
        }
    }
}
