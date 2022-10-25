﻿using Newtonsoft.Json;

namespace TwitchLib.Api.Auth
{
    public class AuthCodeResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string[] Scopes { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        public AuthCodeResponse() { }

        public AuthCodeResponse(RefreshResponse refreshResponse)
        {
            AccessToken = refreshResponse.AccessToken;
            ExpiresIn = refreshResponse.ExpiresIn;
            RefreshToken = refreshResponse.RefreshToken;
            Scopes = refreshResponse.Scopes;
            TokenType = refreshResponse.TokenType;
        }
    }
}