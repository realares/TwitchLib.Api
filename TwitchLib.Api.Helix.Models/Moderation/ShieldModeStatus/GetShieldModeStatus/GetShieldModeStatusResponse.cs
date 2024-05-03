using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Moderation.ShieldModeStatus.GetShieldModeStatus
{
    public record GetShieldModeStatusResponse
    {
        /// <summary>
        /// A list that contains a single object with the broadcaster’s Shield Mode status.
        /// </summary>
        [JsonPropertyName("data")]
        public ShieldModeStatus[] Data { get;  set; } = null!;
    }
}
