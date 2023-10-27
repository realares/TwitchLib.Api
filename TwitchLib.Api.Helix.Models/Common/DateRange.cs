using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Common
{
    public class DateRange
    {
        [JsonPropertyName("started_at")]
        public DateTime StartedAt { get; set; }

        [JsonPropertyName("ended_at")]
        public DateTime EndedAt { get; set; }
    }
}
