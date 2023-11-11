using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Streams.GetStreams
{
    public record GetStreamsResponse
    {
        [JsonPropertyName("data")]
        public Stream[] Streams { get; set; }
        [JsonPropertyName("pagination")]
        public Common.Pagination Pagination { get; set; }
    }
}
