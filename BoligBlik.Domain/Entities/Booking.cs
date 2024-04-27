using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Value;

namespace BoligBlik.Domain.Entities
{
    public class Booking
    {
        [Key]
        public int Number { get; set; }
        
        public DateOnly CreationDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public Boolean Approved { get; set; }
        [Required]
        public Item Item { get; set; }
        public Payment Payment { get; set; }
    }
}
