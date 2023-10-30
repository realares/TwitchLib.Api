﻿using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Analytics
{
    /// <summary>
    /// <para>Response for GetGameAnalytics which gets gets a list of analytic reports for one or more games.</para>
    /// <para>The response contains the URLs used to download the reports (CSV files) and the URLs are only valid for 5 minutes.</para>
    /// </summary>
    public class GetGameAnalyticsResponse
    {
        /// <summary>
        /// <para>A list of game analytics reports.</para>
        /// <para>The reports are returned in no particular order; however, the data within each report is in ascending order by date (newest first).</para>
        /// <para>The report contains one row of data per day of the reporting window and only contains rows the days that the game was used.</para>
        /// <para>A report is available only if the game was broadcast for at least 5 hours over the reporting period.</para>
        /// <para>The array is empty if there are no reports.</para>
        /// </summary>
        [JsonPropertyName("data")]
        public GameAnalytics[] Data { get; set; } = null!;

        /// <summary>
        /// <para>Contains the information used to page through the list of results.</para>
        /// <para>The object is empty if there are no more pages left to page through.</para>
        /// <para>Use the cursor to set the GetGameAnalytics request’s after query parameter.</para>
        /// </summary>
        [JsonPropertyName("pagination")]
        public Common.Pagination Pagination { get; set; } = null!;
    }
}
