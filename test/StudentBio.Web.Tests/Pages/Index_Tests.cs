using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace StudentBio.Pages;

public class Index_Tests : StudentBioWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
