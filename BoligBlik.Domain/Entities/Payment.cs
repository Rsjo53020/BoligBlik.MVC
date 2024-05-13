using BoligBlik.Domain.Common.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Entities
{
    public class Payment : Entity
    {
        public Guid StripeId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public string Status { get; set; }

        public Payment() : base()
        {

        }
    }
}
