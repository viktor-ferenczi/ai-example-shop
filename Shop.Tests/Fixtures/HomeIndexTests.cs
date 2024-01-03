using Shop.Tests.Tools;
using System.Net;
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
        public async Task Get_Index_Status()
        {
            var response = await _webApp.Client.GetAsync("/");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Index_Content()
        {
            var response = await _webApp.Client.GetAsync("/");
            var content = await response.Content.ReadAsStringAsync();

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("index.html");
            reference.Verify(normalizedContent);
        }
    }
}