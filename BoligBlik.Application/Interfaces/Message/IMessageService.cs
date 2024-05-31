using BoligBlik.Application.DTO.Message;

namespace BoligBlik.Application.Interfaces.Message
{
    /// <summary>
    /// Interface for MessageService
    /// </summary>
    public interface IMessageService
    {
        void SendMessage(CreateMessageDTO request);
    }
}
