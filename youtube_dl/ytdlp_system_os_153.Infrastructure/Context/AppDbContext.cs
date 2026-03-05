using Microsoft.EntityFrameworkCore;
using ytdlp_system_os_153.Domain.Entities;

namespace ytdlp_system_os_153.Infrastructure.Context
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(x => x.DateDeleted == null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
