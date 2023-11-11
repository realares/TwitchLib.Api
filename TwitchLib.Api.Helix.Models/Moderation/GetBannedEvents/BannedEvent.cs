using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Moderation.GetBannedEvents
{
    public record BannedEvent
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("event_type")]
        public string EventType { get; set; }
        [JsonPropertyName("event_timestamp")]
        public DateTime EventTimestamp { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("event_data")]
        public EventData EventData { get; set; }
    }
}
