﻿using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BoligBlik.MVC.ProxyServices.Users
{
    public class UserProxy : IUserProxy
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;
        private readonly ILogger<UserProxy> _logger;

        public UserProxy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<bool> CreateUserAsync(CreateUserDTO user)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.PostAsJsonAsync("/api/User", user);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("an error occured while creating a user", ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync("api/User");
                response.EnsureSuccessStatusCode();
                var users = await response.Content.ReadFromJsonAsync<List<UserDTO>>();
                return users;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while fetching users data", ex);
            }
        }

        public async Task<UserDTO> GetUserAsync(string email)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync($"api/User/{email}");
                response.EnsureSuccessStatusCode();
                var user = await response.Content.ReadFromJsonAsync<UserDTO>();
                return user;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while fetching user data", ex);
            }
        }

        public async Task<UserDTO> GetUserAsync(Guid id)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync($"api/User/{id}");
                response.EnsureSuccessStatusCode();
                var user = await response.Content.ReadFromJsonAsync<UserDTO>();
                return user;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while fetching user data", ex);
            }
        }

        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var currentUser = await GetUserAsync(user.EmailAddress);

                if (!currentUser.RowVersion.SequenceEqual(user.RowVersion))
                {
                    throw new DbUpdateConcurrencyException("Concurrency conflict occurred.");
                }

                var response = await httpClient.PutAsJsonAsync("/api/User", user);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating user data", ex);
            }
        }

    }
}
