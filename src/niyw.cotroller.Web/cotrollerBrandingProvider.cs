using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace niyw.cotroller.Web
{
    [Dependency(ReplaceServices = true)]
    public class cotrollerBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "cotroller";
    }
}
