using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Teams
{
    public abstract class TeamBase
    {
        [JsonPropertyName("banner")]
        public string Banner { get; set; }
        [JsonPropertyName("background_image_url")]
        public string BackgroundImageUrl { get; set; }
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
        public string Info { get; set; }
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
        [JsonPropertyName("team_name")]
        public string TeamName { get; set; }
        [JsonPropertyName("team_display_name")]
        public string TeamDisplayName { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}