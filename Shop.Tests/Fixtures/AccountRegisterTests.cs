using Shop.Tests.Tools;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Fixtures
{
    public class AccountRegisterTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public AccountRegisterTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Register_Status()
        {
            _webApp.Logout();

            var response = await _webApp.Client.GetAsync("/Account/Register");
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");
        }

        [Fact]
        public async Task Register_Content()
        {
            _webApp.Logout();

            var response = await _webApp.Client.GetAsync("/Account/Register");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("AccountRegister.html");
            reference.Verify(normalizedContent);
        }

        [Fact]
        public async Task Register_Authenticated_Content()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Account/Register");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("AccountRegisterAuthenticated.html");
            reference.Verify(normalizedContent);
        }
    }
}
