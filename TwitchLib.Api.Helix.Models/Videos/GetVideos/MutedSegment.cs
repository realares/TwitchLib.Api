using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Videos.GetVideos
{
    public record MutedSegment
    {
        [JsonPropertyName("duration")]
        public int Duration { get; set; }
        [JsonPropertyName("offset")]
        public int Offset { get; set; }
    }
}