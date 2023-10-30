using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Bits
{
    public class GetBitsLeaderboardResponse
    {
        /// <summary>
        /// A list of leaderboard leaders. The leaders are returned in rank order by how much they’ve cheered. 
        /// The array is empty if nobody has cheered bits.
        /// </summary>
        [JsonPropertyName("data")]
        public Listing[] Listings { get; set; } = null!;

        /// <summary>
        /// The reporting window’s start and end dates, in RFC3339 format. The dates are calculated by using 
        /// the started_at and period query parameters. If you don’t specify the started_at query parameter, the fields contain empty strings.
        /// </summary>
        [JsonPropertyName("date_range")]
        public DateRange DateRange { get; set; } = null!;

        /// <summary>
        /// The number of ranked users in data. This is the value in the count query parameter or the total 
        /// number of entries on the leaderboard, whichever is less.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
