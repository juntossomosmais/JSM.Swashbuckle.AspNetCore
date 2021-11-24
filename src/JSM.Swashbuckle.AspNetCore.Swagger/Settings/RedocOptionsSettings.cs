namespace JSM.Swashbuckle.AspNetCore.Swagger.Settings
{
    /// <summary>
    /// Providing the properties Redoc Options of Internal Doc and External Doc in AppSettings
    /// </summary>
    public class RedocOptionsSettings
    {
        /// <summary>
        /// Property SpecUrl of Redoc Options
        /// </summary>
        public string SpecUrl { get; set; }
        /// <summary>
        /// Property RoutePrefix of Redoc Options
        /// </summary>
        public string RoutePrefix { get; set; }
        /// <summary>
        /// Property DocumentTitle of Redoc Options
        /// </summary>
        public string DocumentTitle { get; set; }
    }
}
