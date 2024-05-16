using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Value;
using BoligBlik.Entities;

namespace BoligBlik.Domain.Entities
{
    public class Property : Entity
    {
        public BoardMember BoardMember { get; set; }
        public List<Address> Addresses { get; set; }

        public Property() : base()
        {
            
        }
    }
}
