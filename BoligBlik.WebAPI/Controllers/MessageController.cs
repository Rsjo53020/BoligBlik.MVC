﻿using BoligBlik.Application.DTO.Message;
using BoligBlik.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("Create")]
        public IActionResult SendMessage(CreateMessageDTO request)
        {
            CreateMessageDTO createMessageDTO = new CreateMessageDTO
            {
                Sender = request.Sender,
                Recipient = request.Recipient,
                Subject = request.Subject,
                Body = request.Body
            };

            _messageService.SendMessage(createMessageDTO);
            return Ok();
        }
    }
}
