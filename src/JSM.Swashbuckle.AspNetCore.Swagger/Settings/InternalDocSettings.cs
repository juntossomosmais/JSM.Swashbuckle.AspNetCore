using Microsoft.OpenApi.Models;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Settings
{
    public class InternalDocSettings
    {
        public string Name { get; set; }
        public OpenApiInfo Info { get; set; }
        public RedocOptionsSettings RedocOptions { get; set; }
    }
}
