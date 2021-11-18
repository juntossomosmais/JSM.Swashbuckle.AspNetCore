using System;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerMaxLengthAttribute : Attribute
    {
        public int MaxLength { get; private set; }

        /// <summary>
        /// Set max length to open api documentation
        /// </summary>
        /// <param name="maxLength">max length</param>
        public SwaggerMaxLengthAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }
    }
}