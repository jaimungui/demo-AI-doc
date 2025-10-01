using Volo.Abp.Modularity;

namespace demo;

/* Inherit from this class for your domain layer tests. */
public abstract class demoDomainTestBase<TStartupModule> : demoTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
