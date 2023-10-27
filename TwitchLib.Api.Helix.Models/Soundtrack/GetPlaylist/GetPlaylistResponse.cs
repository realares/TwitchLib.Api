using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetPlaylist
{
    public class GetPlaylistResponse
    {
        [JsonPropertyName("data")]
        public PlaylistTrack[] Data { get; set; }
    }
}
