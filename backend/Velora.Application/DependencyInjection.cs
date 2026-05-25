using System.Reflection;
using FluentValidation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Velora.Application.Middlewares;
using Velora.Application.Validation;

namespace Velora.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        var executingAssembly = Assembly.GetExecutingAssembly();

        // Rejestracja MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(executingAssembly));

        // Rejestracja Mapstera
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(executingAssembly);
        services.AddSingleton(config);

        // Automatyczna rejestracja WSZYSTKICH walidatorów w tym projekcie
        services.AddValidatorsFromAssembly(executingAssembly);

        // Rejestracja zachowania walidacji w potoku MediatR
        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(CommandValidationBehavior<,>));

        // Rejestracja Twojego Middleware w kontenerze DI
        services.AddTransient<ExceptionHandlingMiddleware>();

        return services;
    }

    public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
    {
        // Wpięcie middleware do potoku żądań HTTP
        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}
