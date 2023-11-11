using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Games
{
    public record GetGamesResponse
    {
        [JsonPropertyName("data")]
        public Game[] Games { get; set; } = null!;
    }
}
