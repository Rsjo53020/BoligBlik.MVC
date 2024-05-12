using System.Net.Mail;
using BoligBlik.Application.DTO.Message;
using System.Net;
using BoligBlik.Application.Interfaces;

namespace BoligBlik.Infrastructure.Services
{
    internal class MessageService : IMessageService
    {
        public void SendMessage(CreateMessageDTO request)
        {
            MailMessage message = new MailMessage(request.Sender.EmailAddress, request.Recipient.EmailAdress, request.Subject, request.Body);

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential("boligforeningenUnik@gmail.com", "Unik1234")
            };

            try
            {
                client.Send(message);
                Console.WriteLine("Message sent!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed during send message: " + ex.Message);
            }
        }
    }
}
