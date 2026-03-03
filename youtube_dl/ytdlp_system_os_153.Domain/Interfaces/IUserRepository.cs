using ytdlp_system_os_153.Domain.Entities;

namespace ytdlp_system_os_153.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
    }
}
