using JSM.Swashbuckle.AspNetCore.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;
using System.Reflection;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Filters
{
    /// <summary>
    /// Responsible to apply to ignoring properties in schema filter
    /// </summary>
    public class AddSwaggerExcludeSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// Apply to ignoring properties in schema filters
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null)
            {
                return;
            }

            var excludedProperties = context.Type.GetProperties().Where(t => t.GetCustomAttribute<SwaggerExcludeAttribute>() != null);
            foreach (PropertyInfo excludedProperty in excludedProperties)
            {
                if (!string.IsNullOrEmpty(excludedProperty.Name))
                {
                    var toCamelCase = char.ToLowerInvariant(excludedProperty.Name[0]) + excludedProperty.Name.Substring(1);

                    if (schema.Properties.ContainsKey(toCamelCase))
                    {
                        schema.Properties.Remove(toCamelCase);
                    }
                }
            }
        }
    }
}
