using MediatR;

namespace ytdlp_system_os_153.Application.UseCases.CreateUser
{
    public sealed record CreateUserRequest(string Name, string Email, string Password) : IRequest<CreateUserResponse>;
}
