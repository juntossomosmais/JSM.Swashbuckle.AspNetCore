using System;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Attributes
{
    /// <summary>
    /// Providing ignoring attribute to open API documentation
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SwaggerExcludeAttribute : Attribute
    {
    }
}
