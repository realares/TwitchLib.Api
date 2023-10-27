using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetPlaylist
{
    public class PlaylistTrack
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("catalog_tracks")]
        public Track[] CatalogTracks { get; set; }
    }
}
