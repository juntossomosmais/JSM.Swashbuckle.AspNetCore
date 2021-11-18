using FluentAssertions;
using JSM.Swashbuckle.AspNetCore.Swagger.Attributes;
using JSM.Swashbuckle.AspNetCore.Swagger.Filters;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JSM.Swashbuckle.AspNetCore.Test.Unit.Filters
{
    public class AddSwaggerMaxLengthSchemaFilterTest
    {
        [Fact]
        public void ShouldHaveAtLeastOneValidSwaggerMaxLengthAttribute()
        {
            #region arrange           
            var addSwaggerMaxLengthSchemaFilter = new AddSwaggerMaxLengthSchemaFilter();
            OpenApiSchema schema = new OpenApiSchema()
            {
                Properties = new Dictionary<string, OpenApiSchema>
            {
                { "filedToTest", new OpenApiSchema() { MaxLength = 1 } }
            }
            };
            #endregion                  


            var t = typeof(TestAtributte);
            SchemaFilterContext context = new SchemaFilterContext(t, null, null);
            addSwaggerMaxLengthSchemaFilter.Apply(schema, context);


            #region assert
            schema
                .MaxLength?.Should().Be(0);
            #endregion
        }

        [Fact]
        public void ShouldHaveAtLeastOneValidSwaggerRequiredAttribute()
        {
            #region arrange           
            var addSwaggerRequiredSchemaFilter = new AddSwaggerRequiredSchemaFilter();
            OpenApiSchema schema = new OpenApiSchema()
            {
                Properties = new Dictionary<string, OpenApiSchema>
                {
                    { "filedToTest", new OpenApiSchema() { Required = new HashSet<string>()
                            {
                            "Required"
                            }
                        }
                     }
                }
            };

            #endregion

            var t = typeof(TestAtributte);
            SchemaFilterContext context = new SchemaFilterContext(t, null, null);
            addSwaggerRequiredSchemaFilter.Apply(schema, context);


            #region assert
            schema
                .Required.Count().Should().Be(1);
            #endregion
        }
    }

    public class TestAtributte
    {
        [SwaggerRequired]
        [SwaggerMaxLength(1)]
        public string FiledToTest { get; set; }
    }
}