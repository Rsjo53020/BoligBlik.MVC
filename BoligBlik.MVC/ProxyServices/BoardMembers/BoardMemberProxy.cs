using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;

namespace BoligBlik.MVC.ProxyServices.BoardMembers
{
    public class BoardMemberProxy : IBoardMemberProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BoardMemberProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                return new List<BoardMemberDTO>();
            }

        }
        /// <summary>
        /// read a boardmember from title
        /// </summary>
        /// <param name="title"></param>
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
                return new BoardMemberDTO();
            }
        }
        /// <summary>
        /// create a boardmember
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
                return false;
            }
        }
        /// <summary>
        /// update a boardmember
        /// </summary>
        /// <param name="boardMember"></param>
        /// <returns></returns>
        public async Task<bool> UpdateBoardMemberAsync(UpdateBoardMemberDTO boardMember)
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
                return false;
            }
        }
        /// <summary>
        /// deletes a boardmember from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBoardMemberAsync(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.DeleteAsync($"/api/BoardMember/{id}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
