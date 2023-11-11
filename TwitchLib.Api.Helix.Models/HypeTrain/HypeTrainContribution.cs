using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.HypeTrain
{
    public record HypeTrainContribution
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("user")]
        public string UserId { get; set; }
    }
}