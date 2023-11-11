using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;
using TwitchLib.Api.Helix.Models.Users.Internal;

namespace TwitchLib.Api.Helix.Models.Users.GetUserFollows
{
    public record GetUsersFollowsResponse
    {
        [JsonPropertyName("data")]
        public Follow[] Follows { get; set; }
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
        [JsonPropertyName("total")]
        public long TotalFollows { get; set; }
    }
}
