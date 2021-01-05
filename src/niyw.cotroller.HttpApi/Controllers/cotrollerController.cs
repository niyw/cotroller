using niyw.cotroller.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace niyw.cotroller.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class cotrollerController : AbpController
    {
        protected cotrollerController()
        {
            LocalizationResource = typeof(cotrollerResource);
        }
    }
}