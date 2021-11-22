using FluentValidation;
using JSM.Swashbuckle.AspNetCore.Swagger.Settings;
using JSM.Swashbuckle.AspNetCore.Swagger.Validations;
using JSM.Swashbuckle.AspNetCore.Swagger.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using System.IO;
using System.Reflection;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Configurations
{
    /// <summary>
    /// Providing the configurations API documentation in Startup class
    /// </summary>
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Extending the contract to a collection of service descriptors, including Swagger Settings and Schema Filters
        /// </summary>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerSettings = new SwaggerSettings();
            configuration.Bind("Swagger", swaggerSettings);

            var swaggerValidator = new SwaggerSettingsValidator();
            var resultValidate = swaggerValidator.Validate(swaggerSettings);

            if (!resultValidate.IsValid)
            {
                if (resultValidate.Errors.Count > 0)
                    throw new ValidationException(resultValidate.Errors);
            }

            services.AddSwaggerGen(s =>
            {
                s.AddSecurityDefinition(
                    configuration.GetValue<string>("Swagger:Security:Name"),
                    swaggerSettings.Security.Scheme
                );

                s.SwaggerDoc(
                    configuration.GetValue<string>("Swagger:ExternalDoc:Name"),
                    swaggerSettings.ExternalDoc.Info
                );
                s.SwaggerDoc(
                    configuration.GetValue<string>("Swagger:InternalDoc:Name"),
                    swaggerSettings.InternalDoc.Info
                );

                s.DocumentFilter<AddPrefixSwaggerDocumentationPath>();
                s.ExampleFilters();

                var location = Assembly.GetEntryAssembly().Location;
                var directory = Path.GetDirectoryName(location);
                var xmlPath = Path.Combine(directory, swaggerSettings.FilePaths.Api);
                var xmlPathModels = Path.Combine(directory, swaggerSettings.FilePaths.Domain);

                s.IncludeXmlComments(xmlPath);
                s.IncludeXmlComments(xmlPathModels);

                s.SchemaFilter<AddSwaggerRequiredSchemaFilter>();
                s.SchemaFilter<AddSwaggerMaxLengthSchemaFilter>();
            });

            services.AddSwaggerExamples();

            return services;
        }

        /// <summary>
        /// Configuring application pipeline to use Swagger settings (RouteTemplate, InternalDoc RedocOptions and ExternalDoc RedocOptions)
        /// </summary>
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger(c => { c.RouteTemplate = configuration.GetValue<string>("Swagger:RouteTemplate"); });

            app.UseReDoc(options => configuration.Bind("Swagger:InternalDoc:RedocOptions", options));
            app.UseReDoc(options => configuration.Bind("Swagger:ExternalDoc:RedocOptions", options));

            return app;
        }
    }
}
