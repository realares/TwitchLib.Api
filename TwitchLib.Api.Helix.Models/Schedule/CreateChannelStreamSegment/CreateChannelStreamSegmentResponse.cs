using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Schedule.CreateChannelStreamSegment
{
    public record CreateChannelStreamSegmentResponse
    {
        [JsonPropertyName("data")]
        public ChannelStreamSchedule Schedule { get; set; }
    }
}