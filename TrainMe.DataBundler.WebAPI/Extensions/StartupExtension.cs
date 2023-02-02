using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainMe.DataBundler.Models.Common;
using TrainMe.DataBundler.Services.Common;

namespace TrainMe.DataBundler.Extensions
{
    public static class StartupExtension
    {
        public static void AddCommonService(this IServiceCollection services, IConfiguration configuration)
        {
            var eventBusConfig = configuration.GetSection(nameof(EventBusConfiguration)).Get<EventBusConfiguration>();
            if (eventBusConfig is null)
            {
                throw new ArgumentNullException("missing event bus configuration");
            }

            services.AddSingleton<EventBusConfiguration>(a => eventBusConfig);
            services.AddSingleton<IEventBusService, EventBusService>();
        }
    }
}
