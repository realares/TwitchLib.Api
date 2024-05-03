using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Moderation.ShieldModeStatus.UpdateShieldModeStatus
{
    public record ShieldModeStatusRequest
    {
        /// <summary>
        /// A Boolean value that determines whether to activate Shield Mode.
        /// Set to true to activate Shield Mode; otherwise, false to deactivate Shield Mode.
        /// </summary>
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }
    }
}
