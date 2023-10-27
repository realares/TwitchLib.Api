using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Channels.GetChannelVIPs
{
    public class GetChannelVIPsResponse
    {
        /// <summary>
        /// The list of VIPs. The list is empty if the channel doesn’t have VIP users. The list does not include the broadcaster.
        /// </summary>
        [JsonPropertyName("data")]
        public ChannelVIPsResponseModel[] Data { get; set; }
        /// <summary>
        /// Contains the information used to page through the list of results.
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }
}
