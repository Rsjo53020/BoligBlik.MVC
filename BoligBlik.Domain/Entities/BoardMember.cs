using BoligBlik.Domain.Common.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Entities
{
    public class BoardMember : Entity
    {
        public string Title { get; set; }
        public User Member { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public Byte[] Image { get; set; }
        public BoardMember() : base(Guid.NewGuid())
        {
            
        }


    }
}
