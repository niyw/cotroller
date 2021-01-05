using niyw.cotroller.MongoDB;
using Volo.Abp.Modularity;

namespace niyw.cotroller
{
    [DependsOn(
        typeof(cotrollerMongoDbTestModule)
        )]
    public class cotrollerDomainTestModule : AbpModule
    {

    }
}