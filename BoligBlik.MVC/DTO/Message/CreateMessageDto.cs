namespace BoligBlik.MVC.DTO.Message
{
    public class CreateMessageDTO
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
