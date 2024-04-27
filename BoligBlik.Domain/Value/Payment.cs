using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Value
{
    public class Payment
    {
        
        public Guid StripeId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
