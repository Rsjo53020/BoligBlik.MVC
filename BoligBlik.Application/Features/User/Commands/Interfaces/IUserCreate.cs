using BoligBlik.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.User.Commands.Interfaces
{
    public interface IUserCreate
    {
        void Create(CreateUserDto request);
    }
}
