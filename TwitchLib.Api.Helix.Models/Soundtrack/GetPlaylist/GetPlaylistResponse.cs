using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetPlaylist
{
    public record GetPlaylistResponse
    {
        [JsonPropertyName("data")]
        public PlaylistTrack[] Data { get; set; }
    }
}
