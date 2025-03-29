using AAuthentic.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AAuthentic.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AAuthenticDbContext>(options =>
        {
            options.UseNpgsql(
                $"Host={Environment.GetEnvironmentVariable("ASPNETCORE_ASPOTIFY_DB_SERVER")};" +
                $"Port={Environment.GetEnvironmentVariable("ASPNETCORE_ASPOTIFY_DB_PORT")};" +
                $"Username={Environment.GetEnvironmentVariable("ASPNETCORE_ASPOTIFY_DB_USER")};" +
                $"Password={Environment.GetEnvironmentVariable("ASPNETCORE_ASPOTIFY_DB_PASS")};" +
                $"Database={Environment.GetEnvironmentVariable("ASPNETCORE_ASPOTIFY_DB_NAME")};");
        });

        // services.AddDbContext<AAuthenticDbContext>(x => x.UseNpgsql("Host=127.0.0.1;Port=5432;Username=postgres;Password=bt7iC4nN07T0f1nDmyp4ss;Database=AAuthentic"));

        return services;
    }
}