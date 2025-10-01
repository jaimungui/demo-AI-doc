using Xunit;

namespace demo.EntityFrameworkCore;

[CollectionDefinition(demoTestConsts.CollectionDefinitionName)]
public class demoEntityFrameworkCoreCollection : ICollectionFixture<demoEntityFrameworkCoreFixture>
{

}
