﻿using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.DTO.BoardMember
{
    public class AddUserToBoardMemberDTO
    {
        public Guid ID { get; set; }
        public UserDTO User { get; set; }
        public DateOnly StartDate { get; set; }

        public Byte[] RowVersion { get; set; }

    }
}