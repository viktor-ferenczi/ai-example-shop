using Shop.Tests.Tools;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using Shop.Web.Models.Category;

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
        public async Task Get_Authenticated_Status()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var response = await _webApp.Client.GetAsync("/Category/New");
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");
        }

        [Fact]
        public async Task Post_Authenticated_Content()
        {
            _webApp.Logout();
            await _webApp.LoginAsAdmin();

            var model = new CategoryListingModel
            {
                Name = "Test Category",
                Description = "Test Description",
                ImageUrl = "http://test.com/image.jpg"
            };

            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _webApp.Client.PostAsync("/Category/New", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.True(response.IsSuccessStatusCode, $"{response.StatusCode}");

            var normalizedContent = Normalization.NormalizePageContent(responseContent);

            var reference = new Reference("CategoryNew.html");
            reference.Verify(normalizedContent);
        }
    }
}
