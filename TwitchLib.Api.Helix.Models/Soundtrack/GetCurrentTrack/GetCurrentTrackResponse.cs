using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Soundtrack.GetCurrentTrack
{
    public class GetCurrentTrackResponse
    {
        [JsonPropertyName("data")]
        public CurrentTrack[] Data { get; set; }
    }
}
