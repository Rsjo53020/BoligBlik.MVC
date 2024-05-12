using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Mappers;

namespace BoligBlik.Application.Features.User.Mapper
{
    public class UserMapper : IUserMapper
    {
        // this method maps the UserDTO to the User model
        public UserDTO MapModelToUserDTO(Domain.Entities.User user)
        {
            var userDTO = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
            };
            return userDTO;
        }
    }
}
