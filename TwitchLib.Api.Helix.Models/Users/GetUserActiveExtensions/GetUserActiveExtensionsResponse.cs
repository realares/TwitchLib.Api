using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Users.Internal;

namespace TwitchLib.Api.Helix.Models.Users.GetUserActiveExtensions
{
    public record GetUserActiveExtensionsResponse
    {
        [JsonPropertyName("data")]
        public ActiveExtensions Data { get; set; }
    }
}
