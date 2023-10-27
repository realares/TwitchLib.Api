using System.Text.Json.Serialization;

namespace TwitchLib.Api.ThirdParty.AuthorizationFlow
{
    public class RefreshTokenResponse
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("refresh")]
        public string Refresh { get; set; }
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }
    }
}
