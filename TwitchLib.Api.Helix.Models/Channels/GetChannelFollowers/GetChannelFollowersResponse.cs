using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelFollowers
{
    public record GetChannelFollowersResponse
    {
        /// <summary>
        /// The list of users that follow the specified broadcaster.
        /// <para>The list is in descending order by followed_at (with the most recent follower first).</para>
        /// <para>The list is empty if nobody follows the broadcaster.</para>
        /// </summary>
        [JsonPropertyName("data")]
        public ChannelFollower[] Data { get; set; }
        
        /// <summary>
        /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through.
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
        
        /// <summary>
        /// The total number of users that follow this broadcaster. As someone pages through the list, the number of users may change as users follow or unfollow the broadcaster.
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}