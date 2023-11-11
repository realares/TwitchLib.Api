using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.HypeTrain
{
    public record GetHypeTrainResponse
    {
        [JsonPropertyName("data")]
        public HypeTrain[] HypeTrain { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}