﻿using System.Net.Mail;
using BoligBlik.Application.DTO.Message;
using System.Net;
using BoligBlik.Application.Interfaces.Message;

namespace BoligBlik.Infrastructure.Services.Message
{
    public class MessageService : IMessageService
    {
        /// <summary>
        /// This method sends a message using smtp client
        /// </summary>
        public void SendMessage(CreateMessageDTO request)
        {
            // create a MailMessage object with the sender, recipient, subject and body
            MailMessage message = new MailMessage(request.Sender.EmailAddress, request.Recipient.EmailAdress, request.Subject, request.Body);

            // create a SmtpClient object 
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential("boligforeningenUnik@gmail.com", "Unik1234")
            };

            // try to send the message
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
