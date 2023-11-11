using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.HypeTrain
{
    public record HypeTrain
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("event_type")]
        public string EventType { get; set; }
        [JsonPropertyName("event_timestamp")]
        public string EventTimeStamp { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("event_data")]
        public HypeTrainEventData EventData { get; set; }
    }
}