using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence.Database
{
    public sealed class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.Entity<IdentityUserLogin<Guid>>()
                .HasKey(x => x.UserId);

            modelBuilder.Entity<IdentityUserRole<Guid>>()
                .HasKey(x => x.RoleId);

            modelBuilder.Entity<IdentityUserToken<Guid>>()
                .HasKey(x => x.UserId);
        }
            
    }
}
