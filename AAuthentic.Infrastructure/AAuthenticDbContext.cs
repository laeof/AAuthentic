using Microsoft.EntityFrameworkCore;
using AAuthentic.Domain.Entities;

namespace AAuthentic.Infrastructure.Persistence;

public class AAuthenticDbContext : DbContext
{
    public AAuthenticDbContext(DbContextOptions<AAuthenticDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}

