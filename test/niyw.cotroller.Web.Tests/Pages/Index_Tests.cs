using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace niyw.cotroller.Pages
{
    [Collection(cotrollerTestConsts.CollectionDefinitionName)]
    public class Index_Tests : cotrollerWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
