using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Users.Mappers
{
    /// <summary>
    /// Interface for the UserDTOMapper
    /// </summary>
    public interface IUserDTOMapper
    {
        public Domain.Entities.User MapCreateUserToModel(CreateUserDTO DTO);
        public Domain.Entities.User MapUpdateUserToModel(UpdateUserDTO DTO);
        public UserDTO MapDeleteUserToModel(DeleteUserDTO DTO);
    }
}
