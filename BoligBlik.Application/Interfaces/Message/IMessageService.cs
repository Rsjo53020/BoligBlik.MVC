using BoligBlik.Application.DTO.Message;

namespace BoligBlik.Application.Interfaces.Message
{
    public interface IMessageService
    {
        void SendMessage(CreateMessageDTO request);
    }
}
