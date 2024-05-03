using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Chat.Badges.GetChannelChatBadges;
using TwitchLib.Api.Helix.Models.Chat.Badges.GetGlobalChatBadges;
using TwitchLib.Api.Helix.Models.Chat.ChatSettings;
using TwitchLib.Api.Helix.Models.Channels.SendChatMessage;
using TwitchLib.Api.Helix.Models.Chat.Emotes.GetChannelEmotes;
using TwitchLib.Api.Helix.Models.Chat.Emotes.GetEmoteSets;
using TwitchLib.Api.Helix.Models.Chat.Emotes.GetGlobalEmotes;
using System.Text.Json;
using System.Web;
using TwitchLib.Api.Helix.Models.Chat;
using System.Text.Json.Nodes;
using TwitchLib.Api.Helix.Models.Chat.GetUserChatColor;
using TwitchLib.Api.Helix.Models.Moderation.GetModerators;
using System.Drawing;
using TwitchLib.Api.Helix.Models.Chat.SendChatMessage;
using Microsoft.Extensions.Logging;

namespace TwitchLib.Api.Helix
{
    public class Chat : ApiBase
    {
        public Chat(ILogger<Chat> logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) : base(logger, settings, rateLimiter, http)
        { }

        #region Badges
        public Task<GetChannelChatBadgesResponse?> GetChannelChatBadgesAsync(string broadcasterId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };
            return TwitchGetGenericAsync<GetChannelChatBadgesResponse>("/chat/badges", ApiVersion.Helix, getParams, accessToken);
        }

        public Task<GetGlobalChatBadgesResponse?> GetGlobalChatBadgesAsync(string? accessToken = null)
        {
            return TwitchGetGenericAsync<GetGlobalChatBadgesResponse>("/chat/badges/global", ApiVersion.Helix, accessToken: accessToken);
        }
        #endregion

        #region Chatters

        /// <summary>
        /// Gets the list of users that are connected to the specified broadcaster’s chat session.
        /// <para>Note that there is a delay between when users join and leave a chat and when the list is updated accordingly.</para>
        /// <para>Requires a user access token that includes the moderator:read:chatters scope.</para>
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster whose list of chatters you want to get.</param>
        /// <param name="moderatorId">
        /// The ID of the moderator or the specified broadcaster that’s requesting the list of chatters.
        /// <para>This ID must match the user ID associated with the user access token.</para>
        /// </param>
        /// <param name="first">
        /// The maximum number of items to return per page in the response.
        /// <para>The minimum page size is 1 item per page and the maximum is 1,000. The default is 100.</para>
        /// </param>
        /// <param name="after">The cursor used to get the next page of results. The Pagination object in the response contains the cursor’s value. </param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns cref="GetChattersResponse"></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<GetChatSettingsResponse?> GetChatter(
            string broadcasterId, string moderatorId, string? accessToken = null, int first = 100, string? afterCursor = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            if (first < 1 || first > 1000)
                throw new BadParameterException("first cannot be less than 1 or greater than 1000");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
                new KeyValuePair<string, string>("first", first.ToString()),
            };

            if (afterCursor != null)
                getParams.Add(new KeyValuePair<string, string>("after", afterCursor));

            return TwitchGetGenericAsync<GetChatSettingsResponse>("/chat/settings", ApiVersion.Helix, getParams, accessToken);
        }
        #endregion

        #region Emotes

        public Task<GetChannelEmotesResponse?> GetChannelEmotesAsync(string broadcasterId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };
            return TwitchGetGenericAsync<GetChannelEmotesResponse>("/chat/emotes", ApiVersion.Helix, getParams, accessToken);
        }

        public Task<GetEmoteSetsResponse?> GetEmoteSetsAsync(string emoteSetId, string? accessToken = null)
        {
            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("emote_set_id", emoteSetId)
            };
            return TwitchGetGenericAsync<GetEmoteSetsResponse>("/chat/emotes/set", ApiVersion.Helix, getParams, accessToken);
        }

        public Task<GetGlobalEmotesResponse?> GetGlobalEmotesAsync(string? accessToken = null)
        {
            return TwitchGetGenericAsync<GetGlobalEmotesResponse>("/chat/emotes/global", ApiVersion.Helix, accessToken: accessToken);
        }
        #endregion
        
        #region GetChatSettings

        public Task<GetChatSettingsResponse?> GetChatSettingsAsync(string broadcasterId, string moderatorId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId)
            };

            return TwitchGetGenericAsync<GetChatSettingsResponse>("/chat/settings", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region UpdateChatSettings

        public Task<UpdateChatSettingsResponse?> UpdateChatSettingsAsync(string broadcasterId, string moderatorId, ChatSettings settings, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");
            if (settings == null)
                throw new BadParameterException("settings must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId)
            };

            return TwitchPatchGenericAsync<UpdateChatSettingsResponse>("/chat/settings", ApiVersion.Helix, JsonSerializer.Serialize(settings), getParams, accessToken);
        }

        #endregion

        #region Announcements

        /// <summary>
        /// Sends an announcement to the broadcaster’s chat room.
        /// Requires a user access token that includes the moderator:manage:announcements scope.
        /// The ID in the moderator_id query parameter must match the user ID in the access token.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster that owns the chat room to send the announcement to.</param>
        /// <param name="moderatorId">The ID of a user who has permission to moderate the broadcaster’s chat room. This ID must match the user ID in the OAuth token, which can be a moderator or the broadcaster.</param>
        /// <param name="message">The announcement to make in the broadcaster’s chat room.</param>
        /// <param name="color">The color used to highlight the announcement. Possible case-sensitive values are: blue/green/orange/purple/primary(default)</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        public Task SendChatAnnouncementAsync(string broadcasterId, string moderatorId, string message, AnnouncementColors? color = null, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            if (message == null)
                throw new BadParameterException("message must be set");

            if (message.Length > 500)
                throw new BadParameterException("message length must be less than or equal to 500 characters");

            if (color == null)
                color = AnnouncementColors.Primary;

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
            };

            // This should be updated to have a Request Class in the future.
            var json = new JsonObject
            {
                ["message"] = message,
                ["color"] = color.Value
            };

            return TwitchPostAsync("/chat/announcements", ApiVersion.Helix, json.ToString(), getParams, accessToken);
        }

        #endregion

        #region Shoutouts

        /// <summary>
        /// Sends a Shoutout to the specified broadcaster.
        /// </summary>
        /// <param name="fromBroadcasterId">The ID of the broadcaster that’s sending the Shoutout.</param>
        /// <param name="toBroadcasterId"> 	The ID of the broadcaster that’s receiving the Shoutout.</param>
        /// <param name="moderatorId">The ID of the broadcaster or a user that is one of the broadcaster’s moderators. This ID must match the user ID in the access token.</param>
        /// <param name="accessToken"></param>
        /// <exception cref="BadParameterException"></exception>
        public Task SendShoutoutAsync(string fromBroadcasterId, string toBroadcasterId, string moderatorId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(fromBroadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrEmpty(toBroadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("from_broadcaster_id", fromBroadcasterId),
                new KeyValuePair<string, string>("to_broadcaster_id", toBroadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
            };

            return TwitchPostAsync("/chat/shoutouts", ApiVersion.Helix, null, getParams, accessToken);
        }

        #endregion

        #region ChatMessage

        /// <summary>
        /// Sends a message to a chat
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster whose chat room the message will be sent to.</param>
        /// <param name="senderId">	The ID of the user sending the message. This ID must match the user ID in the user access token.</param>
        /// <param name="message">	The message to send. The message is limited to a maximum of 500 characters. Chat messages can also include emoticons. To include emoticons, use the name of the emote. The names are case sensitive. Don’t include colons around the name (e.g., :bleedPurple:). If Twitch recognizes the name, Twitch converts the name to the emote before writing the chat message to the chat room</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<SendChatMessageResponse?> SendChatMessage(
            SendMessageDto sendMessage, 
            string? accessToken = null)
        {
            if (string.IsNullOrEmpty(sendMessage.Broadcaster_id))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrEmpty(sendMessage.Sender_id))
                throw new BadParameterException("senderId must be set");

            if (string.IsNullOrEmpty(sendMessage.Message))
                throw new BadParameterException("message must be set");

            return TwitchPostGenericModelAsync<SendChatMessageResponse>("/chat/messages", ApiVersion.Helix, sendMessage, null, accessToken);
            //return TwitchPostGenericAsync<SendChatMessageResponse>("/chat/messages", ApiVersion.Helix, json.ToString(), null, accessToken);
        }
        //public Task<SendChatMessageResponse?> SendChatMessage(
        //    string broadcasterId, string senderId,
        //    string message, string? reply_parent_message_id = null,
        //    string? accessToken = null)
        //{
        //    if (string.IsNullOrEmpty(broadcasterId))
        //        throw new BadParameterException("broadcasterId must be set");

        //    if (string.IsNullOrEmpty(senderId))
        //        throw new BadParameterException("senderId must be set");

        //    if (string.IsNullOrEmpty(message))
        //        throw new BadParameterException("message must be set");

        //    var json = new JsonObject
        //    {
        //        ["broadcaster_id"] = broadcasterId,
        //        ["sender_id"] = senderId,
        //        ["message"] = message,
        //    };

        //    return TwitchPostGenericAsync<SendChatMessageResponse>("/chat/messages", ApiVersion.Helix, json.ToString(), null, accessToken);
        //}
        

        #endregion

        #region Update User Chat Color
        /// <summary>
        /// Updates the color used for the user’s name in chat from a selection of available colors.
        /// </summary>
        /// <param name="userId">The ID of the user whose chat color you want to update.</param>
        /// <param name="color">The color to use for the user’s name in chat from UserColors selection.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        public Task UpdateUserChatColorAsync(string userId, UserColors color, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(userId))
                throw new BadParameterException("userId must be set");

            if (string.IsNullOrEmpty(color.Value))
                throw new BadParameterException("color must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId),
                new KeyValuePair<string, string>("color", color.Value),
            };

            return TwitchPutAsync("/chat/color", ApiVersion.Helix, null, getParams, accessToken);
        }

        /// <summary>
        /// Updates the color used for the user’s name in chat from a HEX Code.
        /// <para>Turbo or Prime Required</para>
        /// </summary>
        /// <param name="userId">The ID of the user whose chat color you want to update.</param>
        /// <param name="colorHex">The color to use for the user’s name in chat in hex format.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        public Task UpdateUserChatColorAsync(string userId, string colorHex, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(userId))
                throw new BadParameterException("userId must be set");

            if (string.IsNullOrEmpty(colorHex))
                throw new BadParameterException("colorHex must be set");

            if (colorHex.Length != 6)
                throw new BadParameterException("colorHex length must be equal to 6 characters \"######\"");

            var colorEncoded = HttpUtility.UrlEncode("#" + colorHex);

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId),
                new KeyValuePair<string, string>("color", colorEncoded),
            };

            return TwitchPutAsync("/chat/color", ApiVersion.Helix, null, getParams, accessToken);
        }

        #endregion

        #region Get User Chat Color
        /// <summary>
        /// Gets the color used for the user(s)’s name in chat.
        /// </summary>
        /// <param name="userIds">The ID of the users whose color you want to get.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns cref="GetUserChatColorResponse"></returns>
        public Task<GetUserChatColorResponse?> GetUserChatColorAsync(List<string> userIds, string? accessToken = null)
        {
            if (userIds.Count == 0)
                throw new BadParameterException("userIds must contain at least 1 userId");

            var getParams = new List<KeyValuePair<string, string>>();

            foreach (var userId in userIds)
            {
                if (string.IsNullOrEmpty(userId))
                {
                    throw new BadParameterException("userId must be set");
                }

                getParams.Add(new KeyValuePair<string, string>("user_id", userId));
            }

            return TwitchGetGenericAsync<GetUserChatColorResponse>("/chat/color", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion
    }
}
