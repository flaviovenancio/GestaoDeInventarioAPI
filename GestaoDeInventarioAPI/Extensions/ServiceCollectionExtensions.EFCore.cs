using GestaoDeInventarioAPI.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeInventarioAPI.Extensions
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<InventarioContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SQL")));
            

            return services; 
        }
    }
}
