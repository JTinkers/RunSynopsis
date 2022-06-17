using Microsoft.EntityFrameworkCore;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Domain.Auth.Database
{
    public class AuthDbContext : DbContext
    {
        public DbSet<Ban> Bans { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ban>()
                .HasOne(x => x.Judge)
                .WithMany(x => x.GivenBans)
                .HasForeignKey(x => x.JudgeId);

            modelBuilder.Entity<Ban>()
                .HasOne(x => x.User)
                .WithMany(x => x.ReceivedBans)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Token>()
                .HasKey(x => x.Value);

            modelBuilder.Entity<User>(e =>
            {
                e.HasMany(x => x.Permissions)
                    .WithMany(x => x.Users)
                    .UsingEntity<Dictionary<string, object>>("UserPermission",
                        x => x.HasOne<Permission>().WithMany().HasForeignKey("PermissionId"),
                        x => x.HasOne<User>().WithMany().HasForeignKey("UserId"),
                        x => x.ToTable("UserPermissions"))
                    .HasIndex(x => new { x.Username, x.Nickname, x.Mail });

                e.HasMany(x => x.Tokens)
                    .WithOne(x => x.User);

                e.HasIndex(x => x.Username)
                    .IsUnique();

                e.HasIndex(x => x.Nickname)
                    .IsUnique();

                e.HasIndex(x => x.Mail)
                    .IsUnique();
            });

            modelBuilder.Entity<Permission>()
                .HasIndex(x => new { x.Type, x.Value })
                .IsUnique();
        }
    }
}