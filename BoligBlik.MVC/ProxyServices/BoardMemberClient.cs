using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.ProxyServices.Interfaces;

namespace BoligBlik.MVC.ProxyServices
{
    public class BoardMemberClient : IBoardMemberClient
    {
        private readonly HttpClient _httpClient;

        public BoardMemberClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<BoardMemberDTO>> GetBoardMembers()
        {
            var response = await _httpClient.GetAsync("api/BoardMembers");
            response.EnsureSuccessStatusCode();
            var boardMembers = await response.Content.ReadFromJsonAsync<List<BoardMemberDTO>>();
            return boardMembers;
        }

        public async Task<BoardMemberDTO> GetBoardMember(int id)
        {
            var response = await _httpClient.GetAsync($"api/BoardMembers/{id}");
            response.EnsureSuccessStatusCode();
            var boardMember = await response.Content.ReadFromJsonAsync<BoardMemberDTO>();
            return boardMember;
        }

        public async Task<BoardMemberDTO> CreateBoardMember(BoardMemberDTO boardMember)
        {
            var response = await _httpClient.PostAsJsonAsync("api/BoardMembers", boardMember);
            response.EnsureSuccessStatusCode();
            var createdBoardMember = await response.Content.ReadFromJsonAsync<BoardMemberDTO>();
            return createdBoardMember;
        }
    }
}
