using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class Document : Entity
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public String Category { get; set; }

        public string FilePath { get; set; }

        public Document() : base()
        {
        }
    }
}
