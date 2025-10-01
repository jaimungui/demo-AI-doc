using demo.Samples;
using Xunit;

namespace demo.EntityFrameworkCore.Applications;

[Collection(demoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<demoEntityFrameworkCoreTestModule>
{

}
