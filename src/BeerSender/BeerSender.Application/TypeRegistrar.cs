using BeerSender.Application.Packages;

namespace BeerSender.Application;

public interface ITypeRegistrar
{
    void RegisterComponent(ITypeRegistrationContainer services);
}

public interface ITypeRegistrationContainer
{
    void AddTransient<TService>() where TService : class;
    void AddTransient<TService, TImplementation>()
        where TService : class
        where TImplementation: class, TService;
    void AddDbContext<TService>(string name)
        where TService : class;
}

public class TypeRegistrar : ITypeRegistrar
{
    public void RegisterComponent(ITypeRegistrationContainer services)
    {
        // Register all of the application types & services
        services.AddTransient<BoxCreator>();
    }
}