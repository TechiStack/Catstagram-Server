

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

    
    }
}
