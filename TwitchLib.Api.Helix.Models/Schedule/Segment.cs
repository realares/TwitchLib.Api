using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Schedule
{
    public record Segment
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("start_time")]
        public DateTime StartTime { get; set; }
        [JsonPropertyName("end_time")]
        public DateTime EndTime { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("canceled_until")]
        public DateTime? CanceledUntil { get; set; }
        [JsonPropertyName("category")]
        public Category Category { get; set; }
        [JsonPropertyName("is_recurring")]
        public bool IsRecurring { get; set; }
    }
}