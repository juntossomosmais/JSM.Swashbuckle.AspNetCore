using Microsoft.OpenApi.Models;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Settings
{
    /// <summary>
    /// Providing the properties Security in AppSettings
    /// </summary>
    public class SecuritySettings
    {
        /// <summary>
        /// Property Name of Security
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property Scheme of Security
        /// </summary>
        public OpenApiSecurityScheme Scheme { get; set; }
    }
}
