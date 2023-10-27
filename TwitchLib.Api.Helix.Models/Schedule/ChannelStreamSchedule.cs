using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Schedule
{
    public class ChannelStreamSchedule
    {
        [JsonPropertyName("segments")]
        public Segment[] Segments { get; set; }
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }
        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("vacation")]
        public Vacation Vacation { get; set; }
    }
}