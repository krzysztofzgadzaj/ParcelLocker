namespace OutPost.Shared.Infrastructure.Modules.ModuleRegistry;

public interface IRequestRegistry
{
    void Display<TArg, TResult>(string path, Func<IServiceProvider, TArg, Task<TResult>> action) where TArg : class where TResult : class;
}
