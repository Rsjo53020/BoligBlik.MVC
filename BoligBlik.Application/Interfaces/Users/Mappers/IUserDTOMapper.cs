﻿using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Users.Mappers
{
    /// <summary>
    /// Interface for the UserDTOMapper
    /// </summary>
    public interface IUserDTOMapper
    {
        public Domain.Entities.User MapCreateUserToModel(CreateUserDTO DTO);
        public Domain.Entities.User MapUpdateUserToModel(UpdateUserDTO DTO);
        public Domain.Entities.User MapDeleteUserToModel(DeleteUserDTO DTO);
        User MapUserToModel(UserDTO user);
    }
}
