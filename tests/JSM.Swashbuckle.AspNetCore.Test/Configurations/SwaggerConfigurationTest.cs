using FluentAssertions;
using JSM.Swashbuckle.AspNetCore.Test.Helpers.TestingCases;
using JSM.Swashbuckle.AspNetCore.Test.Helpers.TestingStartup;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JSM.Swashbuckle.AspNetCore.Test.Configurations
{
    public class SwaggerConfigurationTest : WebHostFixture<WebHostStartup>
    {
        [Fact(DisplayName = "Should return status ok - get response test swagger configuration")]
        public async Task ShouldReturnOk_GetResponseTestSwaggerConfiguration()
        {
            // Arrange
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"{_client.BaseAddress}get-test-swagger-configuration/")
            {
                Content = content
            };

            // Act
            var response = await _client.SendAsync(request);

            // Assert
            response
                .StatusCode
                .Should()
                .BeEquivalentTo(HttpStatusCode.OK);
        }
    }

}

