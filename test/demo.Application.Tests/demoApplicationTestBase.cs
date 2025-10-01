using Volo.Abp.Modularity;

namespace demo;

public abstract class demoApplicationTestBase<TStartupModule> : demoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
