using PojistovnaWebApp.Triggers;
using Microsoft.EntityFrameworkCore;
/*
 * Konfigurace databázového modelu a přidání triggeru.
*/
namespace PojistovnaWebApp.Data
{
    public class PojisteniServices
    {
        public static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseTriggers(triggerOptions =>
                {
                    triggerOptions
                    .AddTrigger<PojisteneOsobyTrigger>()
                    .AddTrigger<PojistnaUdalostTrigger>();
                });
            });
            return services;
        }
    }
}

