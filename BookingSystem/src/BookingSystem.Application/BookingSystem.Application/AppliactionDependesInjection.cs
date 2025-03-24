using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace BookingSystem.Application;

public static class ApplicationDependenciesInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ApplicationDependenciesInjection).Assembly));

        // Регистрируем кэш
        services.RegisterCaching();

        return services;
    }

    private static void RegisterCaching(this IServiceCollection services)
    {
        // Регистрация кэша в памяти
        services.AddMemoryCache();
    }
}
