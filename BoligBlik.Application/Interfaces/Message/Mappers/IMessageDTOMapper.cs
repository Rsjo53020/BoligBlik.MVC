using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Message.Mappers
{
    // this interface is used to map a message to a DTO
    public interface IMessageDTOMapper
    {
        IMessageDTOMapper Map(Domain.Entities.Message message);
    }
}
