using Microsoft.EntityFrameworkCore;
using ytdlp_system_os_153.Domain.Entities;

namespace ytdlp_system_os_153.Infrastructure.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
