using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Clips.GetClips
{
    public class GetClipsResponse
    {
        [JsonPropertyName("data")]
        public Clip[] Clips { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
