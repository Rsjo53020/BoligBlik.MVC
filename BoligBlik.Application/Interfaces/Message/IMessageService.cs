using BoligBlik.Application.DTO.Message;

namespace BoligBlik.Application.Interfaces.Message
{
    // Interface for sending a message
    public interface IMessageService
    {
        void SendMessage(CreateMessageDTO request);
    }
}
