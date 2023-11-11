using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Schedule
{
    public record Vacation
    {
        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("end_time")]
        public DateTime EndTime { get; set; }
    }
}