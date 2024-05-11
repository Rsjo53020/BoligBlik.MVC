using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Dto.User;

namespace BoligBlik.Application.Features.User.Mapper
{
    public class UserDtoMapper
    {
        public static UserDto MapToDto(Domain.Entities.User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                FormerRole = user.FormerRole,
                Role = user.Role,
                Address = user.Address
            };
        }

        public static Domain.Entities.User MapToEntity(UserDto userDto)
        {
            return new Domain.Entities.User
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.PhoneNumber,
                EmailAddress = userDto.EmailAddress,
                FormerRole = userDto.FormerRole,
                Role = userDto.Role,
                Address = userDto.Address
            };
        }
    }
}
