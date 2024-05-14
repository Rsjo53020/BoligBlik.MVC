﻿using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Users.Queries
{
    /// <summary>
    /// Interface for the UserQuerieService
    /// </summary>
    public interface IUserQuerieService
    {
        Task<UserDTO> ReadUserAsync(string email);
        Task<IEnumerable<UserDTO>> ReadAllUsersAsync();
    }
}
