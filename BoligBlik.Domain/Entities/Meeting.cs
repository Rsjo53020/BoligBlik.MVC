using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class Meeting : Entity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }

        public Meeting() : base()
        {
        }
    }
}
