using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Games
{
    public class GetTopGamesResponse
    {
        [JsonPropertyName("data")]
        public Game[] Data { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
