using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.Common.Entity
{
    /// <summary>
    /// Interface for EntityDTO
    /// </summary>
    public abstract class EntityDTO : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
