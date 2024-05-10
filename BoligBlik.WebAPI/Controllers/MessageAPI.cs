using BoligBlik.Application.Dto.Message;
using BoligBlik.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageAPI : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageAPI(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public IActionResult SendMessage(CreateMessageDto request)
        {
            CreateMessageDto createMessageDto = new CreateMessageDto
            {
                Sender = request.Sender,
                Recipient = request.Recipient,
                Subject = request.Subject,
                Body = request.Body
            };

            _messageService.SendMessage(createMessageDto);
            return Ok();
        }
    }
}
