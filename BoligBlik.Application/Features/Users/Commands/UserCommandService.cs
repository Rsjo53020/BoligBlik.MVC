﻿using System.Data;
using AutoMapper;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.Repositories;
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
        private readonly ILogger<BoardMemberCommandService> _logger;

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
        public async Task CreateUserAsync(CreateUserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);

                    var user = _mapper.Map<User>(request);
                    await _userRepo.CreateUserAsync(user);
                    await _uow.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error creating user with request: {@request}, Exception: {ex}", request, ex);
            }
        }

        /// <summary>
        /// this method Deletes a user using Unit of Work pattern
        /// </summary>
        public async Task DeleteUserAsync(DeleteUserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                var user = _mapper.Map<User>(request);
                await _userRepo.DeleteUserAsync(user); 
                await _uow.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error deleting user with request: {@request}, Exception: {ex}", request, ex);
            }
        }

        /// <summary>
        /// this method updates a user using Unit of Work pattern
        /// </summary>
        public async Task UpdateUserAsync(UpdateUserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                var user = _mapper.Map<User>(request);
                await _userRepo.UpdateUserAsync(user);
                await _uow.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error updating user with request: {@request}, Exception: {ex}", request, ex);
            }
        }
    }
}