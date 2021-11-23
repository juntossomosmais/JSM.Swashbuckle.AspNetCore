using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Filters
{
    /// <summary>
    /// Responsible to apply to prefix version in Swagger documentation
    /// </summary>
    public class AddPrefixSwaggerDocumentationPath : IDocumentFilter
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Inject in the constructor the IConfiguration instance
        /// </summary>
        /// <param name="configuration"></param>
        public AddPrefixSwaggerDocumentationPath(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Apply the prefix version in Swagger document
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            if (swaggerDoc.Info.Title.Equals(
                    _configuration["Swagger:InternalDoc:Info:Title"]))
                return;

            var overwrittenSwaggerSpec = new OpenApiPaths();
            var versionIdentifierPattern = "v[0-9]";
            swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = _configuration["Swagger:BasePath"] } };

            foreach (var (key, value) in swaggerDoc.Paths)
                overwrittenSwaggerSpec
                    .Add(
                        Regex.Match(key, versionIdentifierPattern, RegexOptions.IgnoreCase).Success ?
                            key :
                            string.Concat(
                                _configuration["Swagger:FirstVersionIdentifier"],
                                key),
                        value);

            swaggerDoc.Paths = overwrittenSwaggerSpec;
        }
    }
}
