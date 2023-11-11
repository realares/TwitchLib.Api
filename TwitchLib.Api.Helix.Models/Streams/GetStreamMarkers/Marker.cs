using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Streams.GetStreamMarkers
{
    public record Marker
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("position_seconds")]
        public int PositionSeconds { get; set; }
        [JsonPropertyName("URL")]
        public string Url { get; set; }
    }
}
