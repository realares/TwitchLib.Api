using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack
{
    public class Source
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("content_type")]
        public string ContentType { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("soundtrack_url")]
        public string SoundtrackUrl { get; set; }
        [JsonPropertyName("spotify_url")]
        public string SpotifyUrl { get; set; }
    }
}
