using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Shop.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Tests.Tools;

// ReSharper disable once ClassNeverInstantiated.Global
public class WebAppFixture : IDisposable
{
    private readonly TestServer _server;

    public WebAppFixture()
    {
        var factory = WebHost.CreateDefaultBuilder(Array.Empty<string>())
            .UseStartup<Startup>()
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.Development.json");
            })
            .UseKestrel(options => {
                options.Listen(IPAddress.Loopback, 5000);// Listen for HTTP connections
            });

        _server = new TestServer(factory);
        Client = _server.CreateClient();
    }

    public HttpClient Client { get; }

    public async Task LoginAsAdmin()
    {
        await Login("admin@mail.com", "aA1234");
    }

    public async Task Login(string email, string password)
    {
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("Email", email),
            new KeyValuePair<string, string>("Password", password)
        });

        var response = await Client.PostAsync("/account/login", requestContent);

        // Successful login redirects to HomeIndex
        if (response.StatusCode == HttpStatusCode.Redirect)
        {
            var cookies = response.Headers.GetValues("Set-Cookie");
            var cookieHeader = string.Join(";", cookies);
            Client.DefaultRequestHeaders.Add("Cookie", cookieHeader);
        }
        else
        {
            throw new InvalidOperationException($"Login failed [{response.StatusCode}]: {await response.Content.ReadAsStringAsync()}");
        }
    }

    public void Logout()
    {
        Client.DefaultRequestHeaders.Clear();
    }

    public void Dispose()
    {
        _server.Dispose();
    }
}
