using Microsoft.Extensions.DependencyInjection;
using OneIncTestTask.Facade.Interfaces;
using OneIncTestTask.Facade.Services;
using OneIncTestTask.Utils;

namespace OneIncTestTask.Facade;

public static class Startup
{
    public static IServiceCollection ConfigureFacades(this IServiceCollection services)
    {
        services.ConfigureUtilities();
        services.AddSingleton<IStringEncoderFacade, StringEncoderFacade>();
        return services;
    }
}
