
using BeerSender.Application;

namespace BeerSender.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApiInitializer.Start(args, new List<ITypeRegistrar>(), (_,_) => null);
        }
    }

    public class ApiInitializer
    {
        public static void Start(
            string[] args, 
            IEnumerable<ITypeRegistrar> components,
            Func<IServiceCollection, ConfigurationManager, ITypeRegistrationContainer> containerCreator)
        {
            var builder = WebApplication.CreateBuilder(args);

            var container = containerCreator(builder.Services, builder.Configuration);

            // Add services to the container.
            foreach (var typeRegistrar in components)
            {
                typeRegistrar.RegisterComponent(container);
            }

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
