using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;

namespace BoligBlik.MVC.ProxyServices.Users
{
    public class UserProxy : IUserProxy
    {
        //client factory
        private readonly IHttpClientFactory _clientFactory;
        //logger
        private readonly ILogger<UserProxy> _logger;
        //other proxys
        private readonly IAddressProxy _addressProxy;

        public UserProxy(IHttpClientFactory clientFactory, IAddressProxy addressProxy, ILogger<UserProxy> logger)
        {
            _clientFactory = clientFactory;
            _addressProxy = addressProxy;
            _logger = logger;
        }
        /// <summary>
        /// Creates an User
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
                _logger.LogError("HTTP Request Error:", ex.Message);
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
                return users ?? new List<UserDTO>();
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new List<UserDTO>();
            }
        }
        /// <summary>
        /// Reads an User
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new UserDTO();
            }
        }
        /// <summary>
        /// Updates an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUserAsync(UserDTO user)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.PutAsJsonAsync("/api/User", user);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Deletes an User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
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
                _logger.LogError("HTTP Request Error:", ex.Message);
            }
        }

        /// <summary>
        /// Read all Users Without an Address 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserDTO>> GetUsersWithoutAddressAsync()
        {
            try
            {
                var userResponse = await GetAllUsersAsync();
                var addressResponse = await _addressProxy.GetAllAddressAsync();

                var addressUserIds = new HashSet<Guid>(addressResponse
                    .SelectMany(a => a.Users
                        .Select(u => u.Id)));
                //filter
                var response = userResponse
                    .Where(u => !addressUserIds.Contains(u.Id))
                    .ToList();

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new List<UserDTO>();
            }
        }
    }
}
