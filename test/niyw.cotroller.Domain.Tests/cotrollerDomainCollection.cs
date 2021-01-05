using niyw.cotroller.MongoDB;
using Xunit;

namespace niyw.cotroller
{
    [CollectionDefinition(cotrollerTestConsts.CollectionDefinitionName)]
    public class cotrollerDomainCollection : cotrollerMongoDbCollectionFixtureBase
    {

    }
}
