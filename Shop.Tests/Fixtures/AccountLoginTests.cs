using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Shop.Tests.Tools;
using Shop.Web.Models.Account;

namespace Shop.Tests.Fixtures
{
    public class AccountLoginTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public AccountLoginTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Login_Status_Authenticated()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Account/Login");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Login_Content_Authenticated()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Account/Login");
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("AccountLogin.html");
            reference.Verify(normalizedContent);
        }
    }
}
