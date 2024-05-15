using BeerSender.Application;
using BeerSender.Application.Packages;
namespace BeerSender.Persistence;

public class TypeRegistrar: ITypeRegistrar
{
    public void RegisterComponent(ITypeRegistrationContainer services)
    {
        services.AddTransient<IPackageRepository, PackageRepository>();
        services.AddDbContext<BeerContext>("BeerContext");
    }
}

