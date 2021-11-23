using JSM.Swashbuckle.AspNetCore.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Filters
{
    /// <summary>
    /// Responsible to apply the max length in schema filter
    /// </summary>
    public class AddSwaggerMaxLengthSchemaFilter : ISchemaFilter
    {
        /// <summary>
        /// Apply the max length schema filters in properties
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            PropertyInfo[] properties = context.Type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var attribute = property.GetCustomAttribute(typeof(SwaggerMaxLengthAttribute)) as SwaggerMaxLengthAttribute;

                if (attribute != null)
                {
                    var propertyNameInCamelCasing = char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1);

                    if (schema.Properties.ContainsKey(propertyNameInCamelCasing))
                        schema.Properties[propertyNameInCamelCasing].MaxLength = attribute.MaxLength;
                    else if (schema.Properties.ContainsKey(propertyNameInCamelCasing.ToLower()))
                        schema.Properties[propertyNameInCamelCasing.ToLower()].MaxLength = attribute.MaxLength;
                }
            }
        }
    }
}
