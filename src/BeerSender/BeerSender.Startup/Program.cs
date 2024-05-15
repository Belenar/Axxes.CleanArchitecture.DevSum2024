using BeerSender.API;
using BeerSender.Application;
using BeerSender.Infrastructure.DependencyResolution;

namespace BeerSender.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<ITypeRegistrar> components = new();
            components.Add(new Application.TypeRegistrar());
            components.Add(new Persistence.TypeRegistrar());

            ApiInitializer.Start(args, components, 
                (services, config) => new TypeRegistrationContainer(services, config));
        }
    }
}
