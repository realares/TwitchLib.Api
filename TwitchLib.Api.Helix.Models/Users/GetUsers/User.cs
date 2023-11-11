using System.Text.Json.Serialization;
using System;

namespace TwitchLib.Api.Helix.Models.Users.GetUsers
{
    public record User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("broadcaster_type")]
        public string BroadcasterType { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("profile_image_url")]
        public string ProfileImageUrl { get; set; }
        [JsonPropertyName("offline_image_url")]
        public string OfflineImageUrl { get; set; }
        [JsonPropertyName("view_count")]
        public long ViewCount { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
