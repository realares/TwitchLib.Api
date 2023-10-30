using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Analytics
{
    /// <summary>
    /// <para></para>
    /// </summary>
    public class GameAnalytics
    {
        /// <summary>
        /// <para>An ID that identifies the game that the analytic report was generated for.</para>
        /// </summary>
        [JsonPropertyName("game_id")]
        public string GameId { get; set; } = null!;

        /// <summary>
        /// <para>The URL that you use to download the analytic report.</para>
        /// <para><b>The URL is valid for 5 minutes.</b></para>
        /// </summary>
        [JsonPropertyName("URL")]
        public string Url { get; set; } = null!;

        /// <summary>
        /// <para>The type of analytic report.</para>
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// <para>The reporting period’s start and end dates.</para>
        /// </summary>
        [JsonPropertyName("date_range")]
        public Common.DateRange DateRange { get; set; } = null!;
    }
}
