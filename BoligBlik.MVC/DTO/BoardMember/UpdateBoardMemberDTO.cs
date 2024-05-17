﻿using BoligBlik.MVC.DTO.Interfaces;
using BoligBlik.MVC.DTO.User;

namespace BoligBlik.MVC.DTO.BoardMember
{
    public class UpdateBoardMemberDTO : IEntity, IBaseEntity
    {
        public UserDTO User { get; set; }
        public DateOnly StartDate { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; }
        public Guid? DeletedBy { get; set; }
    }
}
