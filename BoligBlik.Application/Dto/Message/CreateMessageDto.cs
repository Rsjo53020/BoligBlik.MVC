namespace BoligBlik.Application.DTO.Message
{
    public class CreateMessageDTO
    {
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public Domain.Entities.User Sender { get; set; }
        public MessageRecipientDTO Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
