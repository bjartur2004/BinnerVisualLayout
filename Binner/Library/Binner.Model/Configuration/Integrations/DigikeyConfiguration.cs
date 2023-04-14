﻿namespace Binner.Model.Configuration
{
    /// <summary>
    /// Digikey APi configuration settings
    /// </summary>
    public class DigikeyConfiguration : IApiConfiguration
    {
        public bool Enabled { get; set; } = true;

        public string? ApiKey => ClientId;

        /// <summary>
        /// Digikey Client Id
        /// </summary>
        public string? ClientId { get; set; } = string.Empty;

        /// <summary>
        /// Digikey Client Secret
        /// </summary>
        public string? ClientSecret { get; set; } = string.Empty;

        /// <summary>
        /// The oAuth Postback Url - this must match the Callback Url for the App you configured on Digikey's API
        /// </summary>
        public string? OAuthPostbackUrl { get; set; } = "http://localhost:8090/Authorization/Authorize";

        /// <summary>
        /// Path to the Digikey Api
        /// </summary>
        public string? ApiUrl { get; set; } = "https://sandbox-api.digikey.com";

        public bool IsConfigured => Enabled && !string.IsNullOrEmpty(ClientId) && !string.IsNullOrEmpty(ClientSecret) && !string.IsNullOrEmpty(OAuthPostbackUrl) && !string.IsNullOrEmpty(ApiUrl);
    }
}