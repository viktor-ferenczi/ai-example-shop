using Shop.Tests.Tools;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Fixtures
{
    public class CategoryNewTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public CategoryNewTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Get_Status_Authenticated()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Category/New");
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");
        }

        [Fact]
        public async Task Get_Content_Authenticated()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Category/New");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("CategoryNew.html");
            reference.Verify(normalizedContent);
        }
    }
}
