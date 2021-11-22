﻿using Microsoft.OpenApi.Models;

namespace JSM.Swashbuckle.AspNetCore.Swagger.Settings
{
    /// <summary>
    /// Providing the properties of Internal Doc in AppSettings
    /// </summary>
    public class InternalDocSettings
    {
        /// <summary>
        /// Property Name of External Doc
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property Info of External Doc
        /// </summary>
        public OpenApiInfo Info { get; set; }
        /// <summary>
        /// Property RecDocOption of External Doc
        /// </summary>
        public RedocOptionsSettings RedocOptions { get; set; }
    }
}
