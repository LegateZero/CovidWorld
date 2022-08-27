using CV19.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace WpfApp11.Services;

public static class Registrator
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IDataService, DataService>();
        return services;
    }
}