using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.EventSub
{
    public record EventSubSubscription
    {

        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;


        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;


        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;


        [JsonPropertyName("version")]
        public string Version { get; set; } = null!;


        [JsonPropertyName("condition")]
        public Dictionary<string, string> Condition { get; set; } = null!;


        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = null!;


        [JsonPropertyName("transport")]
        public EventSubTransport Transport { get; set; } = null!;

        [JsonPropertyName("cost")]
        public int Cost { get; set; }
    }
}
