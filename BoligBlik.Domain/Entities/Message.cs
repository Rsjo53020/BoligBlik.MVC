using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class Message : Entity
    {
        [Required]
        public User Sender { get; set; }
        [Required]
        public User Reciever { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }

        internal Message() : base(Guid.NewGuid())
        {

        }

        internal Message(Guid id, User sender, User reciever, string subject, string body) : base(id)
        {
            this.Sender = sender;
            this.Reciever = reciever;
            this.Subject = subject;
            this.Body = body;
        }
    }
}
