using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace niyw.cotroller.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<cotrollerWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
