using ePizza.Services.Implementation;
using ePizza.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ePizza.WebUi.Configuration
{
    public class ConfigureDependencies
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }



         
    }
}
