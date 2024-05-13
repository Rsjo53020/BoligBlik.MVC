using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class Message : Entity
    {
        [Required]
        public User Sender { get; set; }
        [Required]
        public User Recipient { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }

        public Message() : base()
        {
            
        }

        public Message(Guid id, User sender, User Recipient, string subject, string body) : base()
        {
            this.Sender = sender;
            this.Recipient = Recipient;
            this.Subject = subject;
            this.Body = body;
        }
    }
}
