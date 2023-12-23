using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Shop.Web;

namespace Shop.Tests;

public class WebAppFixture : IDisposable
{
    private readonly TestServer _server;

    public WebAppFixture()
    {
        var factory = WebHost.CreateDefaultBuilder(Array.Empty<string>())
            .UseStartup<Startup>()
            .UseKestrel(options =>
            {
                options.Listen(IPAddress.Loopback, 5000); // Listen for HTTP connections
            });

        _server = new TestServer(factory);
        Client = _server.CreateClient();
    }

    public HttpClient Client { get; }

    public void Dispose()
    {
        _server.Dispose();
    }
}