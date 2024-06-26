﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Schedule.UpdateChannelStreamSegment
{
    public record UpdateChannelStreamSegmentResponse
    {
        [JsonPropertyName("data")]
        public ChannelStreamSchedule Schedule { get; set; }
    }
}