﻿using JSM.Swashbuckle.AspNetCore.Swagger.Attributes;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Filters
{
    public class AddSwaggerMaxLengthSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            PropertyInfo[] properties = context.Type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                SwaggerMaxLengthAttribute attribute = property.GetCustomAttribute(typeof(SwaggerMaxLengthAttribute)) as SwaggerMaxLengthAttribute;

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
