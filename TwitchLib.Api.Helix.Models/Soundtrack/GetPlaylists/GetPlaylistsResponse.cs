using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetPlaylists
{
    public record GetPlaylistsResponse
    {
        [JsonPropertyName("data")]
        public PlaylistMetadata[] Data { get; set; }
    }
}
