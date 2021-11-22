using System;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Attributes
{
    /// <summary>
    /// Providing setting attribute max length to open API documentation
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerMaxLengthAttribute : Attribute
    {
        /// <summary>
        /// Property max length value to open API documentation
        /// </summary>
        public int MaxLength { get; private set; }

        /// <summary>
        /// Set max length to open API documentation
        /// </summary>
        /// <param name="maxLength">max length</param>
        public SwaggerMaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }
}