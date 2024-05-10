using BoligBlik.Application.Dto.User;

namespace BoligBlik.Application.Dto.Message
{
    public class CreateMessageDto
    {
        public Domain.Entities.User Sender { get; set; }
        public UserMessageRecipientDto Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
