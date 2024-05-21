using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();

            CreateMap<UpdateUserDTO, UserDTO>();
            CreateMap<UserDTO, UpdateUserDTO>();

            CreateMap<UpdateUserViewModel, UserDTO>();
            CreateMap<UserDTO, UpdateUserViewModel>();

            CreateMap<UpdateUserViewModel, UpdateUserDTO>();
            CreateMap<UpdateUserDTO, UpdateUserViewModel>();
        }
    }
}
