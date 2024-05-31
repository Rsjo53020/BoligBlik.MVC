using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Domain.Common.Shared
{
    /// <summary>
    /// Entity abstract class, used for Update,Delete 
    /// </summary>
    public abstract class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
