using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace TwitchLib.Api.Helix.Models.Search
{
    public class Channel
    {
        [JsonPropertyName("game_id")]
        public string GameId { get; set; }
        [JsonPropertyName("game_name")]
        public string GameName { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
        [JsonPropertyName("broadcaster_language")]
        public string BroadcasterLanguage { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
        [JsonPropertyName("is_live")]
        public bool IsLive { get; set; }
        [JsonPropertyName("started_at")]
        public DateTime? StartedAt { get; set; }
        [JsonPropertyName("tag_ids")]
        public List<string> TagIds { get; set; }
    }
}
