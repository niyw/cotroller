using niyw.cotroller.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace niyw.cotroller.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(cotrollerMongoDbModule),
        typeof(cotrollerApplicationContractsModule)
        )]
    public class cotrollerDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
