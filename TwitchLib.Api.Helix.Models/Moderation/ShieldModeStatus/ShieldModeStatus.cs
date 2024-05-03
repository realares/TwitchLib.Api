using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TwitchLib.Api.Helix.Models.Moderation.ShieldModeStatus
{
    public record ShieldModeStatus
    {
        /// <summary>
        /// A Boolean value that determines whether Shield Mode is active.
        /// Is true if the broadcaster activated Shield Mode; otherwise, false.
        /// </summary>
        [JsonPropertyName("is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// An ID that identifies the moderator that last activated Shield Mode.
        /// Is an empty string if Shield Mode hasn’t been previously activated.
        /// </summary>
        [JsonPropertyName("moderator_id")]
        public string ModeratorId { get; set; } = null!;

        /// <summary>
        /// The moderator’s login name. Is an empty string if Shield Mode hasn’t been previously activated.
        /// </summary>
        [JsonPropertyName("moderator_login")]
        public string ModeratorLogin { get; set; } = null!;

        /// <summary>
        /// The moderator’s display name. Is an empty string if Shield Mode hasn’t been previously activated.
        /// </summary>
        [JsonPropertyName("moderator_name")]
        public string ModeratorName { get; set; } = null!;

        /// <summary>
        /// The UTC timestamp (in RFC3339 format) of when Shield Mode was last activated.
        /// Is an empty string if Shield Mode hasn’t been previously activated.
        /// </summary>
        [JsonPropertyName("last_activated_at")]
        public DateTimeOffset LastActivatedAt { get; set; }
    }
}

