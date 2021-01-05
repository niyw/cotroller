using Volo.Abp.Modularity;

namespace niyw.cotroller
{
    [DependsOn(
        typeof(cotrollerApplicationModule),
        typeof(cotrollerDomainTestModule)
        )]
    public class cotrollerApplicationTestModule : AbpModule
    {

    }
}