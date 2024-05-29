using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.MVC.ProxyServices.Users
{
    public class UserProxy : IUserProxy
    {
        //client factory
        private readonly IHttpClientFactory _clientFactory;
        //logger
        private readonly ILogger<UserProxy> _logger;

        public UserProxy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        /// <summary>
        /// creates a user with http call to backend
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

        /// <summary>
        /// reads all users with http call to backend
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
                _logger.LogError("an error occured while reading all users", ex.Message);
                return null;
            }
        }
        /// <summary>
        /// reads a user from backend using http call with an email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
                _logger.LogError("an error occured while reading a user", ex.Message);
                return null;
            }
        }
        /// <summary>
        /// updates a user in the backend using http call
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");


                var response = await httpClient.PutAsJsonAsync("/api/User", user);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("an error occured while updating a user", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError("an error occured while updating a user", ex.Message);
                return false;
            }
        }
        /// <summary>
        /// deletes a user in the backend using http call
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteUserAsync(Guid id, string rowVersion)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.DeleteAsync($"/api/User/{id}/{rowVersion}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("an error occured while deleting a user", ex.Message);
            }
        }
    }
}
