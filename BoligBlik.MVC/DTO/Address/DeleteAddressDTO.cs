using BoligBlik.Domain.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.MVC.DTO.Address
{
    public class DeleteAddressDTO : IEntity, IBaseEntity
    {
        public string Reason { get; set; }
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
