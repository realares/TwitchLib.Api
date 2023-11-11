using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Clips.GetClips
{
    /// <summary>
    /// Response for GetClips which returns one or more video clips that were captured from streams.
    /// </summary>
    public record GetClipsResponse
    {
        /// <summary>
        /// <para>The list of video clips.</para>
        /// <para>For clips returned by game_id or broadcaster_id, the list is in descending order by view count.</para>
        /// <para>For lists returned by id, the list is in the same order as the input IDs.</para>
        /// </summary>
        [JsonPropertyName("data")]
        public Clip[] Clips { get; set; } = null!;

        /// <summary>
        /// <para>The information used to page through the list of results.<br/>
        /// The object is empty if there are no more pages left to page through.</para>
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;
    }
}
