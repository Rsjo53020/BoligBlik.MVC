﻿using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.BoardMembers.Mappers
{
    public interface IBoardMemberMapper
    {
        public BoardMemberDTO MapModelToBoardMemberDTO(BoardMember boardMember);
    }
}
