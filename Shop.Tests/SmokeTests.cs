using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests
{
    public class SmokeTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public SmokeTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Get_returns_statusOK()
        {
            var response = await _webApp.Client.GetAsync("/");
            Assert.Equal(HttpStatusCode.OK ,response.StatusCode);
        }
    }
}