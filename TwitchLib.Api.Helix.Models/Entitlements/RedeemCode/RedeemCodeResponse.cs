using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Entitlements.RedeemCode
{
    public record RedeemCodeResponse
    {
        [JsonPropertyName("data")]
        public Status[] Data { get; set; }
    }
}
