﻿using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Mappers;

namespace BoligBlik.Application.Features.User.Mapper
{
    public class UserDTOMapper : IUserDTOMapper
    {
        /// <summary>
        /// This method maps a CreateUserDTO object to a User object
        /// </summary>
        public Domain.Entities.User MapCreateUserToModel(CreateUserDTO request)
        {
            return new Domain.Entities.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
            };
        }
        /// <summary>
        /// This method maps an UpdateUserDTO object to a User object
        /// </summary>
        public Domain.Entities.User MapUpdateUserToModel(UpdateUserDTO request)
        {
            return new Domain.Entities.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
            };
        }
        /// <summary>
        /// This method maps a DeleteUserDTO object to a UserDTO object
        /// </summary>
        public UserDTO MapDeleteUserToModel(DeleteUserDTO request)
        {
            return new UserDTO
            {
                Id = request.UserId,
            };
        }
    }
}
