using BeerSender.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeerSender.Infrastructure.DependencyResolution
{
    public class TypeRegistrationContainer
        (IServiceCollection services, ConfigurationManager config) 
        : ITypeRegistrationContainer
    {
        public void AddTransient<TService>()
            where TService : class
        {
            services.AddTransient<TService>();
        }

        public void AddTransient<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            services.AddTransient<TService, TImplementation>();
        }

        public void AddDbContext<TService>(string name)
            where TService : class
        {
            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = config.GetConnectionString(name);
            optionsBuilder.UseSqlServer(connectionString);

            var options = optionsBuilder.Options;

            services.AddSingleton(options);
            services.AddScoped<TService>();
        }
    }
}
