using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Videos.GetVideos
{
    public class GetVideosResponse
    {
        [JsonPropertyName("data")]
        public Video[] Videos { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
