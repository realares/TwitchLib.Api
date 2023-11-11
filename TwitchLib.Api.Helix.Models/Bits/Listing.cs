using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public record Listing
    {
        /// <summary>
        /// An ID that identifies a user on the leaderboard.
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// The user’s login name.
        /// </summary>
        [JsonPropertyName("user_login")]
        public string UserLogin { get; set; } = null!;

        /// <summary>
        /// The user’s display name.
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; } = null!;

        /// <summary>
        /// The user’s position on the leaderboard.
        /// </summary>
        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        /// <summary>
        /// The number of Bits the user has cheered.
        /// </summary>
        [JsonPropertyName("score")]
        public int Score { get; set; }
    }
}
