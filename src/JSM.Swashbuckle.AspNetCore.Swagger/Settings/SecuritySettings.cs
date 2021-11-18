using Microsoft.OpenApi.Models;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Settings
{
    public class SecuritySettings
    {
        public string Name { get; set; }
        public OpenApiSecurityScheme Scheme { get; set; }
    }
}
