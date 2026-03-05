using AutoMapper;
using ytdlp_system_os_153.Application.Services.Users.Requests;
using ytdlp_system_os_153.Application.Services.Users.Responses;
using ytdlp_system_os_153.Domain.Entities;

namespace ytdlp_system_os_153.Application.Services.Users.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<CreateUserRequest, User>();

            CreateMap<User, UserResponse>();
        }
    }
}
