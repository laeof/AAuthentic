using AAuthentic.Application.Common.TransformToUnixDate;
using AAuthentic.Application.Interfaces;
using AAuthentic.Application.Interfaces.Repository;
using AAuthentic.Application.Interfaces.Service;
using AAuthentic.Domain.Entities;
using AAuthentic.Infrastructure.Persistence;
using AAuthentic.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AAuthentic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IOAuth2Service, OAuth2Service>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRefreshTokensRepository, RefreshTokensRepository>();
        services.AddScoped<IUserRoleRepository, UserRoleRepository>();

        services.AddDbContext<AAuthenticDbContext>(options =>
        {
            options.UseNpgsql(
                $"Host={Environment.GetEnvironmentVariable("ASPNETCORE_AAUTHENTIC_DB_SERVER")};" +
                $"Port={Environment.GetEnvironmentVariable("ASPNETCORE_AAUTHENTIC_DB_PORT")};" +
                $"Username={Environment.GetEnvironmentVariable("ASPNETCORE_AAUTHENTIC_DB_USER")};" +
                $"Password={Environment.GetEnvironmentVariable("ASPNETCORE_AAUTHENTIC_DB_PASS")};" +
                $"Database={Environment.GetEnvironmentVariable("ASPNETCORE_AAUTHENTIC_DB_NAME")};");
        });

        // services.AddDbContext<AAuthenticDbContext>(x => x.UseNpgsql("Host=127.0.0.1;Port=5432;Username=postgres;Password=bt7iC4nN07T0f1nDmyp4ss;Database=AAuthentic"));

        return services;
    }
}