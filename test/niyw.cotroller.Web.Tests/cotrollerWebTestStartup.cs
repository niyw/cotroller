using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace niyw.cotroller
{
    public class cotrollerWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<cotrollerWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}