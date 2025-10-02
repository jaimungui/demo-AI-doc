using demo.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace demo.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class demoController : AbpControllerBase
{
    protected demoController()
    {
        //commentsssdcs
        //commentdf
        LocalizationResource = typeof(demoResource);
    }
}
