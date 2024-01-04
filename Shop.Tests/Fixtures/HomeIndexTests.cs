using Shop.Tests.Tools;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Fixtures
{
    public class HomeIndexTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public HomeIndexTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Get_Status()
        {
            _webApp.Logout();

            var response = await _webApp.Client.GetAsync("/");
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");
        }

        [Fact]
        public async Task Get_Content()
        {
            _webApp.Logout();

            var response = await _webApp.Client.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("HomeIndex.html");
            reference.Verify(normalizedContent);
        }

        [Fact]
        public async Task Get_Authenticated_Content()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("HomeIndexAuthenticated.html");
            reference.Verify(normalizedContent);
        }
    }
}