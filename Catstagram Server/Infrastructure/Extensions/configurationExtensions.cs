

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catstagram_Server.Infrastructure.Extensions
{
    public static class configurationExtensions
    {

        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => 
                configuration
                            .GetConnectionString("DefaultConnection");

        public static AppSettings GetApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var ApplicationSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(ApplicationSettingsConfig);
            return  ApplicationSettingsConfig.Get<AppSettings>();


            
        }
    }
}
