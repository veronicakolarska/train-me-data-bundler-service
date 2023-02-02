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
            services.Configure<EventBusConfiguration>(a => configuration.GetSection(nameof(EventBusConfiguration)).Bind(a));
            services.AddSingleton<IEventBusService, EventBusService>();
        }
    }
}
