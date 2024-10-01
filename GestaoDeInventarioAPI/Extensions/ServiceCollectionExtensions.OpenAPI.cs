using Microsoft.OpenApi.Models;

namespace GestaoDeInventarioAPI.Extensions
{
    public  static partial class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder AddOpenAPI(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwagger();

            return builder;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services) 
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Description = "MAPI - Gestão de Inventario",
                    Title = "MAPI - Inventario",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Flavio Venancio",
                        Email = "teste@gmail.com"
                    }
                });
            
            });

            return services;
        }

        public static IApplicationBuilder UseOpenAPI(this IApplicationBuilder app, string routePrefix)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                c.RoutePrefix = routePrefix;
            });

            return app;
        }
    }
}
