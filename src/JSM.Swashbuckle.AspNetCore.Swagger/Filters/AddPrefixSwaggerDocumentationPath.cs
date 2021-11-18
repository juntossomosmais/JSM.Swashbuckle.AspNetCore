﻿using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Filters
{
    public class AddPrefixSwaggerDocumentationPath : IDocumentFilter
    {
        private readonly IConfiguration _configuration;

        public AddPrefixSwaggerDocumentationPath(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
