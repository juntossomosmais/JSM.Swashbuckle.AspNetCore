using System;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Attributes
{
    /// <summary>
    /// Providing the mandatory value setting in the open API documentation attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerRequiredAttribute : Attribute
    {
    }
}
