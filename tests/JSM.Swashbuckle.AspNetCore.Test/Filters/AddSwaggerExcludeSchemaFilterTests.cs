using FluentAssertions;
using JSM.Swashbuckle.AspNetCore.Swagger.Filters;
using JSM.Swashbuckle.AspNetCore.Test.Helpers.DTO;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using Xunit;

namespace JSM.Swashbuckle.AspNetCore.Test.Filters
{
    public class AddSwaggerExcludeSchemaFilterTests
    {
        [Fact(DisplayName = "Should Verify swagger excluded filter When there is any excluded field")]
        public void ShouldVerifySwaggerExcludedFilter_WhenThereIsAnyExcludedField_ReturnExcludedFilter()
        {
            // arrange           
            var swaggerExcludeSchemaFilter = new AddSwaggerExcludeSchemaFilter();
            OpenApiSchema schema = new OpenApiSchema()
            {
                Properties = new Dictionary<string, OpenApiSchema>()
                {
                    {
                        "id", new OpenApiSchema()
                    } ,
                    {
                        "name", new OpenApiSchema()
                    },
                    {
                        "description", new OpenApiSchema()
                    }
                }
            };
            var t = typeof(SwaggerExcludeFieldDto);

            //Action
            SchemaFilterContext context = new SchemaFilterContext(t, null, null);
            swaggerExcludeSchemaFilter.Apply(schema, context);

            //assert
            schema.Properties.Should().NotContainKey("id");
            schema.Properties.Should().ContainKey("name");
            schema.Properties.Should().ContainKey("description");
        }

        [Fact(DisplayName = "Should Verify swagger excluded filter When there is no excluded field")]
        public void ShouldVerifySwaggerExcludedFilter_WhenThereIsNoExcludedField_ReturnNoExcludedFilter()
        {
            // arrange           
            var swaggerExcludeSchemaFilter = new AddSwaggerExcludeSchemaFilter();
            OpenApiSchema schema = new OpenApiSchema()
            {
                Properties = new Dictionary<string, OpenApiSchema>() {
                    {
                        "id", new OpenApiSchema()
                    },
                    {
                        "name", new OpenApiSchema()
                    },
                    {
                        "description", new OpenApiSchema()
                    }
                }
            };

            var t = typeof(SwaggerDto);

            //Action
            SchemaFilterContext context = new SchemaFilterContext(t, null, null);
            swaggerExcludeSchemaFilter.Apply(schema, context);

            //assert
            schema.Properties.Should().ContainKey("id");
            schema.Properties.Should().ContainKey("name");
            schema.Properties.Should().ContainKey("description");
        }

        [Fact(DisplayName = "Should Verify swagger excluded filter When there is no properties return empty")]
        public void ShouldVerifySwaggerExcludedFilter_WhenThereIsNoFilterProperties_ReturnEmpty()
        {
            // arrange           
            var swaggerExcludeSchemaFilter = new AddSwaggerExcludeSchemaFilter();
            OpenApiSchema schema = new OpenApiSchema();

            var t = typeof(SwaggerDto);

            //Action
            SchemaFilterContext context = new SchemaFilterContext(t, null, null);
            swaggerExcludeSchemaFilter.Apply(schema, context);

            //assert
            schema.Properties.Should().BeEmpty();
        }

    }
}
