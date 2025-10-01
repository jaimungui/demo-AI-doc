using demo.Samples;
using Xunit;

namespace demo.EntityFrameworkCore.Domains;

[Collection(demoTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<demoEntityFrameworkCoreTestModule>
{

}
