using Shop.Tests.Tools;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using Shop.Web.Models.Order;

namespace Shop.Tests.Fixtures
{
    public class OrderCheckoutTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _webApp;

        public OrderCheckoutTests(WebAppFixture webApp)
        {
            _webApp = webApp;
        }

        [Fact]
        public async Task Get_Authenticated_Content()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var orderIndexModel = new OrderIndexModel
            {
                Address = "123 Test St",
                ZipCode = "12345",
                Country = "USA",
                City = "Test City",
                UserId = "1",
                UserFullName = "Test User"
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(orderIndexModel), Encoding.UTF8, "application/json");

            var response = await _webApp.Client.PostAsync("/Order/Checkout", jsonContent);
            var content = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(content);

            var reference = new Reference("OrderCheckoutAuthenticated.html");
            reference.Verify(normalizedContent);
        }
    }
}
