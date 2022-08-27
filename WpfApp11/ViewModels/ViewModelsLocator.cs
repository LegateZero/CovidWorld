using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WpfApp11.ViewModels;

internal class ViewModelsLocator
{
    public MainWindowViewModel MainWindowModel => 
        App.Host.Services.GetRequiredService<MainWindowViewModel>();
}