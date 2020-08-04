using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeerAPI
{
    public static class CorsExtensions
    {
        public static IServiceCollection AddCorsForApplication(this IServiceCollection services, IHostingEnvironment env, IConfiguration configuration)
        {
            return services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.WithOrigins(configuration["ApiSite"]).AllowCredentials().AllowAnyMethod().AllowAnyHeader();
            }));
        }
    }
}
