using JSM.Swashbuckle.AspNetCore.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Filters
{
    /// <summary>
    /// Responsible to apply the mandatory schema filter
    /// </summary>
    public class AddSwaggerRequiredSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// Apply the mandatory schema filters in properties
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            PropertyInfo[] properties = context.Type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(SwaggerRequiredAttribute));

                if (attribute != null)
                {
                    var propertyNameInCamelCasing = char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1);

                    if (schema.Required == null)
                    {
                        schema.Required = new List<string>
                        {
                            propertyNameInCamelCasing
                        }.ToHashSet();
                    }
                    else
                    {
                        schema.Required.Add(propertyNameInCamelCasing);
                    }
                }
            }
        }
    }
}
