using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.MVC.ProxyServices.Users
{
    public class UserProxy : IUserProxy
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMapper _mapper;

        public UserProxy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
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


        public async Task<bool> UpdateUserAsync(UpdateUserDTO user)
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
