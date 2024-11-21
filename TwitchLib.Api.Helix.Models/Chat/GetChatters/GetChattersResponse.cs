using System.Text.Json.Serialization;
using TwitchLib.Api.Helix.Models.Common;

namespace TwitchLib.Api.Helix.Models.Chat.GetChatters
{
    public record GetChattersResponse
    {
        /// <summary>
        /// The list of users that are connected to the broadcaster’s chat room. The list is empty if no users are connected to the chat room.
        /// </summary>
        [JsonPropertyName("data")]
        public Chatter[] Data { get; set; } = null!;

        /// <summary>
        /// Contains the information used to page through the list of results. The object is empty if there are no more pages left to page through.
        /// <see cref="https://dev.twitch.tv/docs/api/guide#pagination"/>
        /// </summary>
        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; } = null!;

        /// <summary>
        /// The total number of users that are connected to the broadcaster’s chat room.
        /// <para>As you page through the list, the number of users may change as users join and leave the chat room.</para>
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}