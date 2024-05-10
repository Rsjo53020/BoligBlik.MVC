using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Dto.Message;

namespace BoligBlik.Application.Interfaces
{
    public interface IMessageService
    {
        void SendMessage(CreateMessageDto request);
    }
}
