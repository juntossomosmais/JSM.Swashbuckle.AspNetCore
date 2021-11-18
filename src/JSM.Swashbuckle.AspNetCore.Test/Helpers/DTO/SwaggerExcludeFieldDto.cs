using JSM.Swashbuckle.AspNetCore.Swagger.Attributes;

namespace JSM.Swashbuckle.AspNetCore.Test.Helpers.DTO
{
    public class SwaggerExcludeFieldDto
    {

        [SwaggerExclude]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class SwaggerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}