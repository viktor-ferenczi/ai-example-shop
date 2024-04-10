using Shop.Tests.Tools;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Fixtures
{
    public class HomeSearchTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public HomeSearchTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Get_Authenticated_Content()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Home/Search?searchQuery=test");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("HomeSearchAuthenticated.html");
            reference.Verify(normalizedContent);
        }
    }
}
