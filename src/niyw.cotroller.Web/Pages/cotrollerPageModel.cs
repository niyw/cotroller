using niyw.cotroller.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace niyw.cotroller.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class cotrollerPageModel : AbpPageModel
    {
        protected cotrollerPageModel()
        {
            LocalizationResourceType = typeof(cotrollerResource);
        }
    }
}