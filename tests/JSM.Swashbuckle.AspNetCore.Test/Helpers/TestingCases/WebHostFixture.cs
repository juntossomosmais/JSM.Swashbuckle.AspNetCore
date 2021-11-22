using JSM.Swashbuckle.AspNetCore.Test.Helpers.TestingFactory;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net.Http;

namespace JSM.Swashbuckle.AspNetCore.Test.Helpers.TestingCases
{
    //
    //  Summary:
    //    Base class used for integration tests. This class should be used as a test fixture as it creates a
    //    web application based on the supplied TStartup class. Also, dependency injection is configured for
    //    services and databases such as SqlServer and Mongo. This class allows inheritance if subclasses need
    //    different DI configuration or other context variables.
    //
    //    Moreover, if this class is inherited as a fixture, IClassFixture<WebHostFixture<Startup>>, then all
    //    the tests inside the Test class will use the SAME SHARED HttpClient and other variables. Bear in mind that 
    //    this can lead to problems if two tests perform changes on the app client (e.g. add the same header value).
    public class WebHostFixture<TStartup> : IDisposable where TStartup : class
    {
        protected readonly TestingWebApplicationFactory<TStartup> _factory;
        protected readonly HttpClient _client;

        public WebHostFixture()
        {
            // Request for a WebApplication instance
            _factory = new TestingWebApplicationFactory<TStartup>(services =>
                services
                    .AddMvc());

            // Create an HttpClient to send requests to the TestServer
            _client = _factory.WithWebHostBuilder(builder => builder.UseSolutionRelativeContentRoot(Directory.GetCurrentDirectory()))
            .CreateClient();
        }

        public void Dispose() { }
    }
}
