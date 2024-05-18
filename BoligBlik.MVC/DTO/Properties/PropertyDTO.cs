﻿using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.DTO.Interfaces;

namespace BoligBlik.MVC.DTO.Properties
{
    public class PropertyDTO : IBaseEntity, IEntity
    {
        public BoardMemberDTO BoardMember { get; set; }
        public List<AddressDTO> Addresses { get; set; }

        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; }
        public Guid? DeletedBy { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}