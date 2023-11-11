using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Games
{
    public record Game
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("box_art_url")]
        public string BoxArtUrl { get; set; } = null!;
    }
}
