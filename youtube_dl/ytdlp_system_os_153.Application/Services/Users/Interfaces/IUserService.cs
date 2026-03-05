using ytdlp_system_os_153.Application.Services.Users.Requests;
using ytdlp_system_os_153.Application.Services.Users.Responses;

namespace ytdlp_system_os_153.Application.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken);
        Task<UserResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<UserResponse>> ListAsync(CancellationToken cancellationToken);
        Task<UserResponse> UpdateAsync(UpdateUserRequest request, CancellationToken cancellationToken);
        Task<UserResponse> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
