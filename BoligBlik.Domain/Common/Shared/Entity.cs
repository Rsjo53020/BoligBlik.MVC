using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Domain.Common.Shared
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateOnly UpdateStamp { get; set; }
    }
}
