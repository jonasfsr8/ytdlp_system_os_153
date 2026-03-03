using AutoMapper;
using ytdlp_system_os_153.Domain.Entities;

namespace ytdlp_system_os_153.Application.UseCases.CreateUser
{
    public sealed class CreateUserMapper : Profile
    {
        public CreateUserMapper() 
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<User, CreateUserResponse>();
        }
    }
}
