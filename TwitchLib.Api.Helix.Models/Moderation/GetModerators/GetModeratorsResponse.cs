using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Moderation.GetModerators
{
    public record GetModeratorsResponse
    {
        [JsonPropertyName("data")]
        public Moderator[] Data { get; set; } = null!;

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;
    }
}
