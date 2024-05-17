using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.Properties
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
