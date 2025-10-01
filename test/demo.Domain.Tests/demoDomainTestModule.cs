using Volo.Abp.Modularity;

namespace demo;

[DependsOn(
    typeof(demoDomainModule),
    typeof(demoTestBaseModule)
)]
public class demoDomainTestModule : AbpModule
{

}
