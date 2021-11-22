namespace JSM.Swashbuckle.AspNetCore.Swagger.Settings
{
    /// <summary>
    /// Providing the properties Swagger in AppSettings
    /// </summary>
    public class SwaggerSettings
    {
        /// <summary>
        /// Property BasePath of Swagger
        /// </summary>
        public string BasePath { get; set; }
        /// <summary>
        /// Property FirstVersionIdentifier of Swagger
        /// </summary>
        public string FirstVersionIdentifier { get; set; }
        /// <summary>
        /// Property RouteTemplate of Swagger
        /// </summary>
        public string RouteTemplate { get; set; }
        /// <summary>
        /// Property Security of Swagger
        /// </summary>
        public SecuritySettings Security { get; set; }
        /// <summary>
        /// Property Name of Swagger
        /// </summary>
        public InternalDocSettings InternalDoc { get; set; }
        /// <summary>
        /// Property ExternalDoc of Swagger
        /// </summary>
        public ExternalDocSettings ExternalDoc { get; set; }
        /// <summary>
        /// Property FilePaths of Swagger
        /// </summary>
        public FilePathsSettings FilePaths { get; set; }
    }
}
