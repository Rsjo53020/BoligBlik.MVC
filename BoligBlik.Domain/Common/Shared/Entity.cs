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
        protected Entity(Guid newGuid)
        {
            Id = newGuid;
        }

        [Key]
        public Guid Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public DateOnly UpdateStamp { get; set; }
    }
}
