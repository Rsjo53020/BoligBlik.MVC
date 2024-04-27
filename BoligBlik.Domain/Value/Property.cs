using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Domain.Value
{
    public class Property
    {
        [Required]
        public User BoardManager { get; set; }
    }
}
