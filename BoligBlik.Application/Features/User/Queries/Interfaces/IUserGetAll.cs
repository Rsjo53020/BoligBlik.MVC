using BoligBlik.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.User.Queries.Interfaces
{
    public interface IUserGetAll
    {
        IEnumerable<UserGetDTO> ReadAll();
    }
}
