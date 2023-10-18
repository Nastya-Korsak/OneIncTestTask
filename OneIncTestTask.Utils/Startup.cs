using Microsoft.Extensions.DependencyInjection;
using OneIncTestTask.Utils.Interfaces;
using OneIncTestTask.Utils.Services;

namespace OneIncTestTask.Utils;

public static class Startup
{
    public static IServiceCollection ConfigureUtilities(this IServiceCollection services)
    {
        services.AddSingleton<IStringEncoder, StringToBase64Encoder>();
        return services;
    }
}
