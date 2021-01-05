using System;
using System.Collections.Generic;
using System.Text;
using niyw.cotroller.Localization;
using Volo.Abp.Application.Services;

namespace niyw.cotroller
{
    /* Inherit your application services from this class.
     */
    public abstract class cotrollerAppService : ApplicationService
    {
        protected cotrollerAppService()
        {
            LocalizationResource = typeof(cotrollerResource);
        }
    }
}
