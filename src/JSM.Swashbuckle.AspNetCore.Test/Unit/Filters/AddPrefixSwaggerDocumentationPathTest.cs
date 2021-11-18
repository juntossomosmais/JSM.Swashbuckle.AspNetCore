using FluentAssertions;
using JSM.Swashbuckle.AspNetCore.Swagger.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Moq;
using System.Linq;
using Xunit;

namespace JSM.Swashbuckle.AspNetCore.Test.Unit.Filters
{
    public class AddPrefixSwaggerDocumentationPathTest
    {
        Mock<IConfigurationRoot> GetMockedConfig()
        {
            var configuration = new Mock<IConfigurationRoot>();
            configuration
                .Setup(m => m["Swagger:InternalDoc:Info:Title"])
                .Returns("Internal Documentation Title");
            configuration
                .Setup(m => m["Swagger:ExternalDoc:Info:Title"])
                .Returns("External Documentation Title");
            configuration
                .Setup(m => m["Swagger:BasePath"])
                .Returns("/gatewayRoutePrefix");
            configuration
                .Setup(m => m["Swagger:FirstVersionIdentifier"])
                .Returns("/v1");

            return configuration;
        }

        [Fact]
        public void ShouldAddFirstVersionPrefixInExternalRoutesWithoutVersion()
        {
            #region arrange
            var configuration = GetMockedConfig();
            var documentFilter = new AddPrefixSwaggerDocumentationPath(configuration.Object);

            var swaggerDoc = new OpenApiDocument();
            swaggerDoc.Paths = new OpenApiPaths();
            swaggerDoc.Info = new OpenApiInfo();
            swaggerDoc.Paths.Add("/path/to/firstRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/path/to/secondRoute", new OpenApiPathItem());
            swaggerDoc.Info.Title = "External Documentation Title";
            #endregion

            #region act
            documentFilter.Apply(swaggerDoc, null);
            #endregion

            #region assert
            swaggerDoc
                .Paths
                .All(path => path.Key.Contains("/v1"))
                .Should()
                .BeTrue();
            #endregion
        }

        [Fact]
        public void ShouldNotAddFirstVersionPrefixInExternalRoutesWithVersion()
        {
            #region arrange
            var configuration = GetMockedConfig();
            var documentFilter = new AddPrefixSwaggerDocumentationPath(configuration.Object);

            var swaggerDoc = new OpenApiDocument();
            swaggerDoc.Paths = new OpenApiPaths();
            swaggerDoc.Info = new OpenApiInfo();
            swaggerDoc.Paths.Add("/v2/path/to/firstRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/v3/path/to/secondRoute", new OpenApiPathItem());
            swaggerDoc.Info.Title = "External Documentation Title";
            #endregion

            #region act
            documentFilter.Apply(swaggerDoc, null);
            #endregion

            #region assert
            swaggerDoc
                .Paths
                .All(path => !path.Key.Contains("/v1"))
                .Should()
                .BeTrue();
            #endregion
        }

        [Fact]
        public void ShouldAddBasePathInAllExternalRoutes()
        {
            #region arrange
            var configuration = GetMockedConfig();
            var documentFilter = new AddPrefixSwaggerDocumentationPath(configuration.Object);

            var swaggerDoc = new OpenApiDocument();
            swaggerDoc.Paths = new OpenApiPaths();
            swaggerDoc.Info = new OpenApiInfo();
            swaggerDoc.Paths.Add("/path/to/firstRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/v2/path/to/secondRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/v3/path/to/thirdRoute", new OpenApiPathItem());
            swaggerDoc.Info.Title = "External Documentation Title";
            #endregion

            #region act
            documentFilter.Apply(swaggerDoc, null);
            #endregion

            #region assert
            swaggerDoc
                .Servers
                .First()
                .Url
                .Should()
                .BeEquivalentTo("/gatewayRoutePrefix");
            #endregion
        }

        [Fact]
        public void ShouldNotAddFirstVersionPrefixInAllInternalRoutes()
        {
            #region arrange
            var configuration = GetMockedConfig();
            var documentFilter = new AddPrefixSwaggerDocumentationPath(configuration.Object);

            var swaggerDoc = new OpenApiDocument();
            swaggerDoc.Paths = new OpenApiPaths();
            swaggerDoc.Info = new OpenApiInfo();
            swaggerDoc.Paths.Add("/path/to/firstRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/v2/path/to/secondRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/v3/path/to/thirdRoute", new OpenApiPathItem());
            swaggerDoc.Info.Title = "Internal Documentation Title";
            #endregion

            #region act
            documentFilter.Apply(swaggerDoc, null);
            #endregion

            #region assert
            swaggerDoc
                .Paths
                .All(path => !path.Key.Contains("/v1"))
                .Should()
                .BeTrue();
            #endregion
        }

        [Fact]
        public void ShouldNotAddBasePathInAllInternalRoutes()
        {
            #region arrange
            var configuration = GetMockedConfig();
            var documentFilter = new AddPrefixSwaggerDocumentationPath(configuration.Object);

            var swaggerDoc = new OpenApiDocument();
            swaggerDoc.Paths = new OpenApiPaths();
            swaggerDoc.Info = new OpenApiInfo();
            swaggerDoc.Paths.Add("/path/to/firstRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/v2/path/to/secondRoute", new OpenApiPathItem());
            swaggerDoc.Paths.Add("/v3/path/to/thirdRoute", new OpenApiPathItem());
            swaggerDoc.Info.Title = "Internal Documentation Title";
            #endregion

            #region act
            documentFilter.Apply(swaggerDoc, null);
            #endregion

            #region assert
            swaggerDoc
                .Servers
                .Should()
                .BeEmpty();
            #endregion
        }
    }
}
