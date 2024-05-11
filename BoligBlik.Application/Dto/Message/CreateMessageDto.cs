namespace BoligBlik.Application.Dto.Message
{
    public class CreateMessageDto
    {
        public DateTime CreatedAt { get; set; }
        public Domain.Entities.User Sender { get; set; }
        public MessageRecipientDto Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
