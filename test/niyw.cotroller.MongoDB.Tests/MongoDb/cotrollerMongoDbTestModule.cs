using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace niyw.cotroller.MongoDB
{
    [DependsOn(
        typeof(cotrollerTestBaseModule),
        typeof(cotrollerMongoDbModule)
        )]
    public class cotrollerMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var stringArray = cotrollerMongoDbFixture.ConnectionString.Split('?');
                        var connectionString = stringArray[0].EnsureEndsWith('/')  +
                                                   "Db_" +
                                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}
