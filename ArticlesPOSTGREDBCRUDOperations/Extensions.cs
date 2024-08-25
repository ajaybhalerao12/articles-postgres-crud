using ArticlesPOSTGREDBCRUDOperations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace ArticlesPOSTGREDBCRUDOperations
{
    public static class Extensions
    {
        public static IServiceCollection RegisteredServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            RegisterCustomServices(services, configuration);

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            RegisterSwaggerServices(services);
            return services;
        }

        private static void RegisterCustomServices(IServiceCollection services, IConfiguration configuration)
        {
            // Add DBContext in DI container
            services.AddDbContext<AppDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
        }

        private static void RegisterSwaggerServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
