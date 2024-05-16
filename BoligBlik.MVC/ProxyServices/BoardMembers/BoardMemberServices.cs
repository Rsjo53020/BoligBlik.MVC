﻿using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;

namespace BoligBlik.MVC.ProxyServices.BoardMembers
{
    public class BoardMemberServices : IBoardMemberServices
    {
        private readonly HttpClient _httpClient;

        public BoardMemberServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        /// <summary>
        /// Read all boardmembers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BoardMemberDTO>> GetAllBoardMembers()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/BoardMembers");
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
        public async Task<BoardMemberDTO> GetBoardMember(string title)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/BoardMembers/{title}");
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
        public async Task<bool> CreateBoardMember(CreateBoardMemberDTO boardMember)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/BoardMembers", boardMember);
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
        public async Task<bool> UpdateBoardMember(UpdateBoardMemberDTO boardMember)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync("api/BoardMembers", boardMember);
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
        public async Task<bool> DeleteBoardMember(Guid id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/BoardMembers{id}");
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
