using Shop.Tests.Tools;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Fixtures
{
    public class FoodNewTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public FoodNewTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Get_Authenticated_Content()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Food/New");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("FoodNewAuthenticated.html");
            reference.Verify(normalizedContent);
        }
    }
}
