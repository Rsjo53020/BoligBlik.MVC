using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;

namespace BoligBlik.MVC.ProxyServices.BoardMembers
{
    public class BoardMemberProxy : IBoardMemberProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<BoardMemberProxy> _logger;

        public BoardMemberProxy(IHttpClientFactory httpClientFactory, ILogger<BoardMemberProxy> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        /// <summary>
        /// Read all boardmembers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BoardMemberDTO>> GetAllBoardMembersAsync()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync("api/BoardMember");
                response.EnsureSuccessStatusCode();
                var boardMembers = await response.Content.ReadFromJsonAsync<List<BoardMemberDTO>>();
                return boardMembers;
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new List<BoardMemberDTO>();
            }

        }
        /// <summary>
        /// Read a boardmember 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BoardMemberDTO> GetBoardMemberAsync(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync($"/api/BoardMember/{id}");
                response.EnsureSuccessStatusCode();
                var boardMember = await response.Content.ReadFromJsonAsync<BoardMemberDTO>();
                return boardMember;
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new BoardMemberDTO();
            }
        }
        /// <summary>
        /// Create a boardmember
        /// </summary>
        /// <param name="boardMember"></param>
        /// <returns></returns>
        public async Task<bool> CreateBoardMemberAsync(CreateBoardMemberDTO boardMember)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.PostAsJsonAsync("/api/BoardMember", boardMember);
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
        /// Update a boardmember
        /// </summary>
        /// <param name="boardMember"></param>
        /// <returns></returns>
        public async Task<bool> UpdateBoardMemberAsync(BoardMemberDTO boardMember)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.PutAsJsonAsync("/api/BoardMember", boardMember);
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
        /// Delete a boardmember
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBoardMemberAsync(Guid id, string rowVersion)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.DeleteAsync($"/api/BoardMember/{id}/{rowVersion}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return false;
            }
        }
    }
}
