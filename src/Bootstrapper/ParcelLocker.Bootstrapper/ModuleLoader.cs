using System.Reflection;
using ParcelLocker.Shared.Abstractions.Modules;

namespace Bootstrapper;

public static class ModuleLoader
{
    public static IEnumerable<Assembly> GetModuleAssemblies(IConfigurationRoot configuration)
    {
        var moduleFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "ParcelLocker.Modules.*.*.dll");
        var moduleAssemblies = moduleFiles.Select(x => AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(x)));

        var enabledModules = new List<Assembly>();

        foreach (var module in moduleAssemblies)
        {
            var moduleName = module.FullName!.Split(".")[2];
            var moduleEnabled = configuration.GetSection($"{moduleName}:module:enabled").Get<bool>();

            if (moduleEnabled)
            {
                enabledModules.Add(module);
            }
        }
        
        return enabledModules;
    }

    public static List<IModule> GetModules(IEnumerable<Assembly> assemblies)
        => assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(IModule).IsAssignableFrom(x) && !x.IsInterface)
            .Select(Activator.CreateInstance)
            .Cast<IModule>()
            .ToList();
}
