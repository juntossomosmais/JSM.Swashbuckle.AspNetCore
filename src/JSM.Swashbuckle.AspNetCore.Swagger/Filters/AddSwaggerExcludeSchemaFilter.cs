using JSM.Swashbuckle.AspNetCore.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Filters
{
    public class AddSwaggerExcludeSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var excludedProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);
            foreach (PropertyInfo excludedProperty in excludedProperties)
            {
                if (string.IsNullOrEmpty(excludedProperty.Name))
                    continue;

                var toCamelCase = char.ToLowerInvariant(excludedProperty.Name[0]) + excludedProperty.Name.Substring(1);

                if (schema.Properties.ContainsKey(toCamelCase))
                {
                    schema.Properties.Remove(toCamelCase);
                }
            }
        }
    }
}
