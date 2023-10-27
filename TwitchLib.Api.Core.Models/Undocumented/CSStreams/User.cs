using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Core.Models.Undocumented.CSStreams
{
    public class User
    {
        [JsonPropertyName("mature")]
        public bool Mature { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("game")]
        public string Game { get; set; }
        [JsonPropertyName("localized_game")]
        public LocalizedGame LocalizedGame { get; set; }
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("bio")]
        public string Bio { get; set; }
        [JsonPropertyName("partner")]
        public bool Partner { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonPropertyName("delay")]
        public string Delay { get; set; }
        [JsonPropertyName("prerolls")]
        public bool Prerolls { get; set; }
        [JsonPropertyName("postrolls")]
        public bool Postrolls { get; set; }
        [JsonPropertyName("primary_team_name")]
        public string PrimaryTeamName { get; set; }
        [JsonPropertyName("primary_team_display_name")]
        public string PrimaryTeamDisplayName { get; set; }
        [JsonPropertyName("logo")]
        public string Logo { get; set; }
        [JsonPropertyName("banner")]
        public string Banner { get; set; }
        [JsonPropertyName("video_banner")]
        public string VideoBanner { get; set; }
        [JsonPropertyName("background")]
        public string Background { get; set; }
        [JsonPropertyName("profile_banner")]
        public string ProfileBanner { get; set; }
        [JsonPropertyName("profile_banner_background_color")]
        public string ProfileBannerBackgroundColor { get; set; }
        [JsonPropertyName("url")]
        public string Url { get; set; }
        [JsonPropertyName("views")]
        public int Views { get; set; }
        [JsonPropertyName("followers")]
        public int Followers { get; set; }
    }
}
