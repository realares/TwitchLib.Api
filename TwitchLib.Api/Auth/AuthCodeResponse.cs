using System.Text.Json.Serialization;

namespace TwitchLib.Api.Auth
{
    public class AuthCodeResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string[] Scopes { get; set; }

        [JsonPropertyName("token_type")]
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