using Shop.Tests.Tools;
using System.Threading.Tasks;
using Xunit;

namespace Shop.Tests.Fixtures
{
    public class OrderCheckoutCompleteTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public OrderCheckoutCompleteTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Get_Authenticated_Content()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Order/CheckoutComplete");
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("OrderCheckoutComplete.html");
            reference.Verify(normalizedContent);
        }
    }
}
