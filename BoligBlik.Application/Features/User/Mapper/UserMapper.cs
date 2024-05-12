using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Mappers;

namespace BoligBlik.Application.Features.User.Mapper
{
    public class UserMapper : IUserMapper
    {
        /// <summary>
        /// this method maps a User entity to a UserDTO object
        /// </summary>
        public UserDTO MapModelToUserDTO(Domain.Entities.User user)
        {
            var userDTO = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                EmailAddress = user.EmailAddress,
                Role = user.Role,
                FormerRole = user.FormerRole,
                Address = new AddressDTO
                {
                    Street = user.Address.Street,   
                    HouseNumber = user.Address.HouseNumber,
                    Floor = user.Address.Floor,
                    DoorNumber = user.Address.DoorNumber,
                    City = user.Address.PostalCode.City,
                    PostalCode = user.Address.PostalCode.PostalcodeNumber,
                },
            };
            return userDTO;
        }
    }
}
