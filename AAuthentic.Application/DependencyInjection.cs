using AAuthentic.Application.Common.TransformToUnixDate;
using AAuthentic.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AAuthentic.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITransformToUnixDate, TransformToUnixDate>();

        return services;
    }
}