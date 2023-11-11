using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Entitlements.GetCodeStatus
{
    public record GetCodeStatusResponse
    {
        [JsonPropertyName("data")]
        public Status[] Data { get; set; }
    }
}
