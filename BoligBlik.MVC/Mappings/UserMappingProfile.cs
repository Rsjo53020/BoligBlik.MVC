using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
            CreateMap<CreateUserDTO, CreateUserViewModel>().ReverseMap();
        }
    }
}
