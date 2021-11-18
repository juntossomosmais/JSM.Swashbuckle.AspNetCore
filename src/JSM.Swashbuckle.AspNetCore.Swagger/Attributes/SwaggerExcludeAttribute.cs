using System;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute
    {
    }
}
