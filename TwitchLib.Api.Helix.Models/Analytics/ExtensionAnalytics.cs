using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Analytics
{
    public class ExtensionAnalytics
    {
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; } = null!;

        [JsonPropertyName("URL")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("date_range")]
        public Common.DateRange DateRange { get; set; } = null!;
    }
}
