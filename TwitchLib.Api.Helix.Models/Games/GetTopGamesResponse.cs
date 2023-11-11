using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Games
{
    public record GetTopGamesResponse
    {
        [JsonPropertyName("data")]
        public Game[] Data { get; set; } = null!;

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;
    }
}
