using BoligBlik.Application.DTO.Message;

namespace BoligBlik.Application.Interfaces
{
    /// <summary>
    /// Interface for the MessageService
    /// </summary>
    public interface IMessageService
    {
        void SendMessage(CreateMessageDTO request);
    }
}
