using Microsoft.Extensions.Localization;
using demo.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace demo;

[Dependency(ReplaceServices = true)]
public class demoBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<demoResource> _localizer;

    public demoBrandingProvider(IStringLocalizer<demoResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
