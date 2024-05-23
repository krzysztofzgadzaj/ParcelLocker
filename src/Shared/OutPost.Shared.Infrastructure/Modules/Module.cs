using Microsoft.Extensions.Configuration;

namespace OutPost.Shared.Infrastructure.Modules;

public static class Module
{
    public static void RegisterModuleSettings(this IConfigurationBuilder configurationBuilder, string environmentName)
    {
        var moduleFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "appsettings.*.json");

        foreach (var file in moduleFiles)
        {
            configurationBuilder.AddJsonFile(file);
        }
        
        var envModuleFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"appsettings.*.{environmentName}.json");
        
        foreach (var file in envModuleFiles)
        {
            configurationBuilder.AddJsonFile(file);
        }
    }
}
