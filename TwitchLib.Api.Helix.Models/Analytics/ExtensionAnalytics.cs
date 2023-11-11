using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Analytics
{
    /// <summary>
    /// <para>A analytic report for an extension.</para>
    /// </summary>
    public record ExtensionAnalytics
    {
        /// <summary>
        /// <para>An ID that identifies the extension that the analytic report was generated for.</para>
        /// </summary>
        [JsonPropertyName("extension_id")]
        public string ExtensionId { get; set; } = null!;

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
