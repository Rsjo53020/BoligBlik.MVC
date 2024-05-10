using BoligBlik.Application.Dto.User;

namespace BoligBlik.Application.Dto.Message
{
    public class CreateMessageDto
    {
        public UserMessageDto Sender { get; set; }
        public UserMessageDto Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
