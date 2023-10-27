using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetPlaylists
{
    public class GetPlaylistsResponse
    {
        [JsonPropertyName("data")]
        public PlaylistMetadata[] Data { get; set; }
    }
}
