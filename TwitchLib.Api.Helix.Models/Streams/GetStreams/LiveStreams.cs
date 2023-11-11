using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Streams.GetStreams
{
    public record LiveStreams
    {
        #region Total
        [JsonPropertyName("_total")]
        public int Total { get; set; }
        #endregion
        #region Streams
        [JsonPropertyName("streams")]
        public Stream[] Streams { get; set; }
        #endregion
    }
}
