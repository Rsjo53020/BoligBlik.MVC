using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class Meeting : Entity
    {
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Description { get; set; }

        public List<Document> Document { get; set; }
        public List<User> Users { get; set; }

        public Meeting() : base()
        {
        }
    }
}
