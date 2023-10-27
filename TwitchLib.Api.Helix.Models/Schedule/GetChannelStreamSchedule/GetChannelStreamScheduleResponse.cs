using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Schedule.GetChannelStreamSchedule
{
    public class GetChannelStreamScheduleResponse
    {
        [JsonPropertyName("data")]
        public ChannelStreamSchedule Schedule { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}