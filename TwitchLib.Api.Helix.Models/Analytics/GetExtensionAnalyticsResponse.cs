﻿using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Analytics
{
    /// <summary>
    /// <para>The response for GetExtensionAnalytics that gets a list of analytic reports for one or more extensions.</para>
    /// <para>The response contains the URLs used to download the reports (CSV files) and the URLs are only valid for 5 minutes.</para>
    /// </summary>
    public class GetExtensionAnalyticsResponse
    {
        /// <summary>
        /// <para>A list of analytic reports for the extensions.</para>
        /// <para>The reports are returned in no particular order; however, the data within each report is in ascending order by date (newest first).</para>
        /// <para>The report contains one row of data per day of the reporting window and only contains rows for the days that the extension was used.</para>
        /// <para>The array is empty if there are no reports.</para>
        /// </summary>
        [JsonPropertyName("data")]
        public ExtensionAnalytics[] Data { get; set; } = null!;

        /// <summary>
        /// <para>Contains the information used to page through the list of results.</para>
        /// <para>The object is empty if there are no more pages left to page through.</para>
        /// <para>Use the cursor to set the GetExtensionAnalytics request’s after query parameter.</para>
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;
    }
}
