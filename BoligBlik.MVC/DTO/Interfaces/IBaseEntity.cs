using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.MVC.DTO.Interfaces
{
    public interface IBaseEntity
    {
        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; }
        public Guid? DeletedBy { get; set; }
    }
}
