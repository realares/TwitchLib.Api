using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Users.Internal;

namespace TwitchLib.Api.Helix.Models.Users.GetUsers
{
    public record GetUsersResponse
    {
        [JsonPropertyName("data")]
        public User[] Users { get; set; }
    }
}
