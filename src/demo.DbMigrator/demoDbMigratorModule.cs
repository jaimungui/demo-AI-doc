using demo.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace demo.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(demoEntityFrameworkCoreModule),
    typeof(demoApplicationContractsModule)
    )]
public class demoDbMigratorModule : AbpModule
{
}
