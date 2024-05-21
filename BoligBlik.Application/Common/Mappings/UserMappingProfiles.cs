using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Domain.Entities;
using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Common.Mappings
{
    public class UserMappingProfiles : Profile
    {
        /// <summary>
        /// Creates Mapping profiles on user, using AutoMapper
        /// </summary>
        public UserMappingProfiles()
        {
            // CreateUserDTO
            CreateMap<CreateUserDTO, User>();
            CreateMap<User, CreateUserDTO>();

            // DeleteUserDTO
            CreateMap<DeleteUserDTO, User>();
            CreateMap<User, DeleteUserDTO>();

            CreateMap<UpdateUserDTO, User>();
            CreateMap<User, UpdateUserDTO>();

            // UserDTO
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }

    }
}
