using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Domain.Entities
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public User Sender { get; set; }
        [Required]
        public User Reciever { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
