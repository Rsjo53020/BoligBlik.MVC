using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Users.Mappers
{
    /// <summary>
    /// Interface for the UserMapper
    /// </summary>
    public interface IUserMapper
    {
        public UserDTO MapModelToUserDTO(Domain.Entities.User user);
    }
}
