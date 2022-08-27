using Microsoft.Extensions.DependencyInjection;

namespace WpfApp11.ViewModels;

public static class Registrator
{
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        return services;
    }
}