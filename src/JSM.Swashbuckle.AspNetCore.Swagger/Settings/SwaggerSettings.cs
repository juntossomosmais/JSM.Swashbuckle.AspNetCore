namespace JSM.Swashbuckle.AspNetCore.Swagger.Settings
{
    public class SwaggerSettings
    {
        public string BasePath { get; set; }
        public string FirstVersionIdentifier { get; set; }
        public string RouteTemplate { get; set; }
        public SecuritySettings Security { get; set; }
        public InternalDocSettings InternalDoc { get; set; }
        public ExternalDocSettings ExternalDoc { get; set; }
        public FilePathsSettings FilePaths { get; set; }
    }
}
