﻿//-----------------------------------------------------------------------
// <copyright file="SwaggerUiOwinSettings.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

#if AspNetOwin
namespace NSwag.AspNet.Owin
#else
namespace NSwag.AspNetCore
#endif
{
    /// <summary>The settings for UseSwaggerUi.</summary>
    public class SwaggerUiOwinSettings : SwaggerOwinSettings
    {
        /// <summary>Gets or sets the swagger UI route.</summary>
        public string SwaggerUiRoute { get; set; } = "/swagger";

        /// <summary>Gets or sets the Swagger UI OAuth2 client settings.</summary>
        public OAuth2Settings OAuth2Client { get; set; }
    }
}