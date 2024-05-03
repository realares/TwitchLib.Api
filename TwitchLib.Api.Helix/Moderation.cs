using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Moderation.AutomodSettings;
using TwitchLib.Api.Helix.Models.Moderation.BanUser;
using TwitchLib.Api.Helix.Models.Moderation.BlockedTerms;
using TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus;
using TwitchLib.Api.Helix.Models.Moderation.CheckAutoModStatus.Request;
using TwitchLib.Api.Helix.Models.Moderation.GetBannedEvents;
using TwitchLib.Api.Helix.Models.Moderation.GetBannedUsers;
using TwitchLib.Api.Helix.Models.Moderation.GetModeratorEvents;
using TwitchLib.Api.Helix.Models.Moderation.GetModerators;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Net.Http.Json;
using TwitchLib.Api.Helix.Models.Moderation.ShieldModeStatus.GetShieldModeStatus;
using TwitchLib.Api.Helix.Models.Moderation.ShieldModeStatus;
using TwitchLib.Api.Helix.Models.Moderation.ShieldModeStatus.UpdateShieldModeStatus;
using TwitchLib.Api.Helix.Models.Users.GetUserFollows;
using System.Linq;
using TwitchLib.Api.Helix.Models.Moderation.GetChannelVIPs;
using System.Net;
using Microsoft.Extensions.Logging;

namespace TwitchLib.Api.Helix
{
    public class Moderation : ApiBase
    {
        public Moderation(ILogger<Moderation> logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) : base(logger, settings, rateLimiter, http)
        {
        }

        #region CheckAutoModeStatus

        /// <summary>
        /// Checks whether AutoMod would flag the specified message for review.
        /// AutoMod is a moderation tool that holds inappropriate or harassing chat messages for moderators to review. Moderators approve or deny the messages that AutoMod flags; only approved messages are released to chat. AutoMod detects misspellings and evasive language automatically. For information about AutoMod, see How to Use AutoMod.
        /// </summary>
        /// <param name="messages">The message to check.</param>
        /// <param name="broadcasterId">The ID of the broadcaster whose AutoMod settings and list of blocked terms are used to check the message. This ID must match the user ID in the access token.</param>
        /// <param name="accessToken">The ID of the broadcaster whose AutoMod settings and list of blocked terms are used to check the message. This ID must match the user ID in the access token.</param>
        /// <returns></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<CheckAutoModStatusResponse?> CheckAutoModStatusAsync(List<Message> messages, string broadcasterId, string? accessToken = null)
        {
            if (messages == null || messages.Count == 0)
                throw new BadParameterException("messages cannot be null and must be greater than 0 length");

            if (broadcasterId == null || broadcasterId.Length == 0)
                throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broacaster_id", broadcasterId)
            };

            MessageRequest request = new MessageRequest()
            {
                Messages = messages.ToArray()
            };

            return TwitchPostGenericAsync<CheckAutoModStatusResponse>(
                "/moderation/enforcements/status", ApiVersion.Helix, JsonSerializer.Serialize(request), getParams, accessToken);
        }

        #endregion

        #region Manage Held AutoMod Messages

        /// <summary>
        /// Allow or deny the message that AutoMod flagged for review. For information about AutoMod, see How to Use AutoMod.
        /// To get messages that AutoMod is holding for review, subscribe to the automod-queue.<moderator_id>.<channel_id> topic using PubSub. PubSub sends a notification to your app when AutoMod holds a message for review.
        /// </summary>
        /// <param name="userId">The moderator who is approving or denying the held message. This ID must match the user ID in the access token.</param>
        /// <param name="msgId">The ID of the message to allow or deny.</param>
        /// <param name="action">The action to take for the message. Possible values are: ALLOW, DENY</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        /// <exception cref="BadParameterException"></exception>
        public async Task<bool> ManageHeldAutoModMessagesAsync(string userId, string msgId, 
            ManageHeldAutoModMessageActionEnum action
            , string? accessToken = null
            , bool throwExceptions = false)
        {
            if (String.IsNullOrEmpty(userId) || String.IsNullOrEmpty(msgId))
                throw new BadParameterException("userId and msgId cannot be null and must be greater than 0 length");

            JsonObject json = new JsonObject();
            json["user_id"] = userId;
            json["msg_id"] = msgId;
            json["action"] = action.ToString().ToUpper();

            var webresult = await TwitchPostAsync("/moderation/automod/message", ApiVersion.Helix, json.ToString(), accessToken: accessToken);
            return HandleBooleanResponse(webresult, throwExceptions);
        }

        #endregion

        #region GetAutomodSettings

        public Task<GetAutomodSettingsResponse?> GetAutomodSettingsAsync(string broadcasterId, string moderatorId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new("broadcaster_id", broadcasterId),
                new("moderator_id", moderatorId),
            };

            return TwitchGetGenericAsync<GetAutomodSettingsResponse>("/moderation/automod/settings", ApiVersion.Helix, getParams, accessToken);
           
        }

        #endregion

        #region UpdateAutomodSettings

        public Task<UpdateAutomodSettingsResponse?> UpdateAutomodSettingsAsync(string broadcasterId, string moderatorId, AutomodSettings settings, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            // you can set the overall level, OR you can set individual levels, but not both

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
            };

            return TwitchPutGenericAsync<UpdateAutomodSettingsResponse>("/moderation/automod/settings", ApiVersion.Helix, JsonSerializer.Serialize(settings), getParams, accessToken);
        }

        #endregion

        #region GetBannedUsers

        public Task<GetBannedUsersResponse?> GetBannedUsersAsync(
            string broadcasterId, List<string>? userIds = null, string? after = null, string? before = null, string? accessToken = null)
        {
            if (broadcasterId == null || broadcasterId.Length == 0)
                throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            if (userIds != null && userIds.Count > 0)
                foreach (var userId in userIds)
                    getParams.Add(new KeyValuePair<string, string>("user_id", userId));

            if (after != null)
                getParams.Add(new KeyValuePair<string, string>("after", after));

            if (before != null)
                getParams.Add(new KeyValuePair<string, string>("before", before));

            return TwitchGetGenericAsync<GetBannedUsersResponse>("/moderation/banned", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region BanUsers

        /// <summary>
        /// Ban or Timeout an user from chat. If a duration is specified it is treated as a timeout, if you omit a duration is a permanent ban.
        /// </summary>
        /// <param name="broadcasterId">Id of the broadcaster channel from which you want to ban/timeout somebody</param>
        /// <param name="moderatorId">Id of the moderator that wants to ban/timeout somebody (if you use the broadcaster account this has to be the broadcasterId)</param>
        /// <param name="banUserRequest">request object containing the information about the ban like the userId of the user to ban, the reason and optional duration</param>
        /// <param name="accessToken">optional access token to override the one used while creating the TwitchAPI object</param>
        /// <returns cref="BanUserResponse"></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<BanUserResponse?> BanUserAsync(string broadcasterId, string moderatorId, BanUserRequest banUserRequest, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            if (banUserRequest == null)
                throw new BadParameterException("banUserRequest cannot be null");

            if (string.IsNullOrWhiteSpace(banUserRequest.UserId))
                throw new BadParameterException("banUserRequest.UserId must be set");

            if (banUserRequest.Reason == null)
                throw new BadParameterException("banUserRequest.Reason cannot be null and must be set to at least an empty string");

            if (banUserRequest.Duration.HasValue)
                if (banUserRequest.Duration.Value <= 0 || banUserRequest.Duration.Value > 1209600)
                    throw new BadParameterException("banUserRequest.Duration has to be between including 1 and including 1209600");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId)
            };

            var body = new
            {
                data = banUserRequest
            };

            return TwitchPostGenericAsync<BanUserResponse>("/moderation/bans", ApiVersion.Helix, JsonSerializer.Serialize(body), getParams, accessToken);
        }

        #endregion

        #region UnbanUsers

        public Task UnbanUserAsync(string broadcasterId, string moderatorId, string userId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");
            if (string.IsNullOrEmpty(userId))
                throw new BadParameterException("userId must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
                new KeyValuePair<string, string>("user_id", userId)
            };

            return TwitchDeleteAsync("/moderation/bans", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        // todo Resolve Unban Requests

        #region GetBlockedTerms

        public Task<GetBlockedTermsResponse?> GetBlockedTermsAsync(string broadcasterId, string moderatorId, string? after = null, int first = 20, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");
            if (first < 1 || first > 100)
                throw new BadParameterException("first must be greater than 0 and less than 101");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
                new KeyValuePair<string, string>("first", first.ToString())
            };

            if (!string.IsNullOrEmpty(after))
                getParams.Add(new KeyValuePair<string, string>("after", after));

            return TwitchGetGenericAsync<GetBlockedTermsResponse>("/moderation/blocked_terms", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region AddBlockedTerm

        public Task<AddBlockedTermResponse?> AddBlockedTermAsync(string broadcasterId, string moderatorId, string term, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");
            if (string.IsNullOrEmpty(term))
                throw new BadParameterException("term must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
            };

            JsonObject body = new JsonObject();
            body["text"] = term;

            return TwitchPostGenericAsync<AddBlockedTermResponse>("/moderation/blocked_terms", ApiVersion.Helix, body.ToString(), getParams, accessToken);
        }

        #endregion

        #region RemoveBlockedTerm

        public Task RemoveBlockedTermAsync(string broadcasterId, string moderatorId, string termId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");
            if (string.IsNullOrEmpty(moderatorId))
                throw new BadParameterException("moderatorId must be set");
            if (string.IsNullOrEmpty(termId))
                throw new BadParameterException("termId must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
                new KeyValuePair<string, string>("id", termId)
            };

            return TwitchDeleteAsync("/moderation/blocked_terms", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region Delete Chat Messages

        /// <summary>
        /// Removes a single chat message or all chat messages from the broadcaster’s chat room.
        /// <para>!!! If no messageId is specified, the request removes all messages in the broadcaster’s chat room. !!!</para>
        /// <para>The message must have been created within the last 6 hours.</para>
        /// <para>The message must not belong to the broadcaster.</para>
        /// <para>The message must not belong to another moderator.</para>
        /// <para>Requires a user access token that includes the moderator:manage:chat_messages scope. </para>
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster that owns the chat room to remove messages from.</param>
        /// <param name="moderatorId">The ID of a user that has permission to moderate the broadcaster’s chat room. This ID must match the user ID in the OAuth token.</param>
        /// <param name="messageId">
        /// The ID of the message to remove.
        /// <para>!!! If not specified, the request removes all messages in the broadcaster’s chat room. !!!</para>
        /// </param>
        /// <param name="accessToken">optional access token to override the one used while creating the TwitchAPI object</param>
        /// <returns></returns>
        public Task DeleteChatMessagesAsync(string broadcasterId, string moderatorId, string messageId = null, string accessToken = null)
        {
            if (string.IsNullOrWhiteSpace(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrWhiteSpace(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId),
            };

            if (!string.IsNullOrWhiteSpace(messageId))
            {
                getParams.Add(new KeyValuePair<string, string>("message_id", messageId));
            }

            return TwitchDeleteAsync("/moderation/chat", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        // todo Get Moderated Channels

        #region GetModerators

        public Task<GetModeratorsResponse?> GetModeratorsAsync(
            string broadcasterId, List<string>? userIds = null, int first = 20, string? after = null, string? accessToken = null)
        {
            if (broadcasterId == null || broadcasterId.Length == 0)
                throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            if (userIds != null && userIds.Count > 0)
                foreach (var userId in userIds)
                    getParams.Add(new KeyValuePair<string, string>("user_id", userId));


            if (first != 20)
                getParams.Add(new KeyValuePair<string, string>("first", first.ToString()));

            if (after != null)
                getParams.Add(new KeyValuePair<string, string>("after", after));

            return TwitchGetGenericAsync<GetModeratorsResponse>("/moderation/moderators", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region AddChannelModerator

        /// <summary>
        /// Adds a moderator to the broadcaster’s chat room.
        /// Rate Limits: The channel may add a maximum of 10 moderators within a 10 seconds period.
        /// Requires a user access token that includes the channel:manage:moderators scope.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster that owns the chat room.</param>
        /// <param name="userId">The ID of the user to add as a moderator in the broadcaster’s chat room.</param>
        /// <param name="accessToken">optional access token to override the one used while creating the TwitchAPI object</param>
        /// <returns></returns>
        public Task AddChannelModeratorAsync(string broadcasterId, string userId, string accessToken = null)
        {
            if (string.IsNullOrWhiteSpace(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrWhiteSpace(userId))
                throw new BadParameterException("userId must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new("broadcaster_id", broadcasterId),
                new("user_id", userId),
            };

            return TwitchPostAsync("/moderation/moderators", ApiVersion.Helix, null, getParams, accessToken);
        }

        #endregion

        #region RemoveChannelModerator

        /// <summary>
        /// Removes a moderator from the broadcaster’s chat room.
        /// Rate Limits: The channel may remove a maximum of 10 moderators within a 10 seconds period.
        /// Requires a user access token that includes the channel:manage:moderators scope.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster that owns the chat room.</param>
        /// <param name="userId">The ID of the user to remove as a moderator from the broadcaster’s chat room.</param>
        /// <param name="accessToken">optional access token to override the one used while creating the TwitchAPI object</param>
        /// <returns></returns>
        public Task RemoveChannelModeratorAsync(string broadcasterId, string userId, string? accessToken = null)
        {
            if (string.IsNullOrWhiteSpace(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrWhiteSpace(userId))
                throw new BadParameterException("userId must be set");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new("broadcaster_id", broadcasterId),
                new("user_id", userId),
            };

            return TwitchDeleteAsync("/moderation/moderators", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region GetChannelVIPs

        /// <summary>
        /// Gets a list of the channel’s VIPs.
        /// Requires a user access token that includes the channel:read:vips scope.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster whose list of VIPs you want to get.</param>
        /// <param name="userIds">Filters the list for specific VIPs. </param>
        /// <param name="first">The maximum number of items to return per page in the response. Max 100</param>
        /// <param name="after">The cursor used to get the next page of results.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns cref="GetChannelVIPsResponse"></returns>
        public Task<GetChannelVIPsResponse?> GetVIPsAsync(
            string broadcasterId, List<string>? userIds = null, int first = 20, string? after = null
            , string? accessToken = null
            , bool throwExceptions = false)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (first > 100 & first <= 0)
                throw new BadParameterException("first must be greater than 0 and less then 101");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new("broadcaster_id", broadcasterId),
                new("first", first.ToString())
            };

            if (userIds != null)
            {
                if (userIds.Count == 0)
                    throw new BadParameterException("userIds must contain at least 1 userId if a list is included in the call");

                getParams.AddRange(userIds.Select(userId => new KeyValuePair<string, string>("userId", userId)));
            }

            if (!string.IsNullOrWhiteSpace(after))
                getParams.Add(new KeyValuePair<string, string>("after", after));

            return TwitchGetGenericAsync<GetChannelVIPsResponse>(
                "/channels/vips", ApiVersion.Helix, getParams, accessToken,
                null, null, throwExceptions);
        }

        #endregion

        #region AddChannelVIP

        /// <summary>
        /// Adds a VIP to the broadcaster’s chat room.
        /// Rate Limits: The channel may add a maximum of 10 VIPs within a 10 seconds period.
        /// Requires a user access token that includes the channel:manage:vips scope.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster that’s granting VIP status to the user.</param>
        /// <param name="userId">The ID of the user to add as a VIP in the broadcaster’s chat room.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        public async Task<bool> AddChannelVIPAsync(string broadcasterId, string userId, string? accessToken = null, bool throwExceptions = false)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrEmpty(userId))
                throw new BadParameterException("userId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new("broadcaster_id", broadcasterId),
                new("user_id", userId),
            };

            //return TwitchPostAsync("/channels/vips", ApiVersion.Helix, null, getParams, accessToken);
            var webresult = await TwitchPostAsync("/channels/vips", ApiVersion.Helix, null, getParams, accessToken);
            return HandleBooleanResponse(webresult, throwExceptions);
        }

        #endregion

        #region RemoveChannelVIP

        /// <summary>
        /// Removes a VIP from the broadcaster’s chat room.
        /// Rate Limits: The channel may remove a maximum of 10 VIPs within a 10 seconds period.
        /// Requires a user access token that includes the channel:manage:vips scope.
        /// </summary>
        /// <param name="broadcasterId">The ID of the user to remove as a VIP from the broadcaster’s chat room.</param>
        /// <param name="userId">The ID of the broadcaster that’s removing VIP status from the user.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        public Task RemoveChannelVIPAsync(string broadcasterId, string userId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrEmpty(userId))
                throw new BadParameterException("userId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new("broadcaster_id", broadcasterId),
                new("user_id", userId),
            };

            return TwitchDeleteAsync("/channels/vips", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region UpdateShieldModeStatus

        /// <summary>
        /// Activates or deactivates the broadcaster’s Shield Mode.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster whose Shield Mode activation status you want to get.</param>
        /// <param name="moderatorId">The ID of the broadcaster or a user that is one of the broadcaster’s moderators. This ID must match the user ID in the access token.</param>
        /// <param name="request">ShieldModeStatusRequest Model to request</param>
        /// <param name="accessToken">optional access token to override the one used while creating the TwitchAPI object</param>
        /// <returns cref="ShieldModeStatus"></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<ShieldModeStatus?> UpdateShieldModeStatusAsync(string broadcasterId, string moderatorId, ShieldModeStatusRequest request, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrWhiteSpace(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId)
            };

            return TwitchPutGenericAsync<ShieldModeStatus>("/moderation/shield_mode", ApiVersion.Helix, JsonSerializer.Serialize(request), getParams, accessToken);
        }

        #endregion

        #region GetShieldModeStatus

        /// <summary>
        /// Gets the broadcaster’s Shield Mode activation status.
        /// Requires a user access token that includes the moderator:read:shield_mode or moderator:manage:shield_mode scope.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster whose Shield Mode activation status you want to get.</param>
        /// <param name="moderatorId">The ID of the broadcaster or a user that is one of the broadcaster’s moderators. This ID must match the user ID in the access token.</param>
        /// <param name="accessToken">optional access token to override the one used while creating the TwitchAPI object</param>
        /// <returns cref="GetShieldModeStatusResponse"></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<GetShieldModeStatusResponse?> GetShieldModeStatusAsync(string broadcasterId, string moderatorId, string? accessToken = null)
        {
            if (string.IsNullOrWhiteSpace(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (string.IsNullOrWhiteSpace(moderatorId))
                throw new BadParameterException("moderatorId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId),
                new KeyValuePair<string, string>("moderator_id", moderatorId)
            };

            return TwitchGetGenericAsync<GetShieldModeStatusResponse>("/moderation/shield_mode", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion


        #region GetModeratorEvents

        // No Documentation on this
        public Task<GetModeratorEventsResponse?> GetModeratorEventsAsync(string broadcasterId, List<string>? userIds = null, string? accessToken = null)
        {
            if (broadcasterId == null || broadcasterId.Length == 0)
                throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            if (userIds != null && userIds.Count > 0)
                foreach (var userId in userIds)
                    getParams.Add(new KeyValuePair<string, string>("user_id", userId));

            return TwitchGetGenericAsync<GetModeratorEventsResponse>("/moderation/moderators/events", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region GetBannedEvents

        // No Documentation on this
        public Task<GetBannedEventsResponse?> GetBannedEventsAsync(
            string broadcasterId, List<string>? userIds = null, string? after = null, string? first = null, string? accessToken = null)
        {
            if (broadcasterId == null || broadcasterId.Length == 0)
                throw new BadParameterException("broadcasterId cannot be null and must be greater than 0 length");

            var getParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            if (userIds != null && userIds.Count > 0)
                foreach (var userId in userIds)
                    getParams.Add(new KeyValuePair<string, string>("user_id", userId));

            if (after != null)
                getParams.Add(new KeyValuePair<string, string>("after", after));

            if (first != null)
                getParams.Add(new KeyValuePair<string, string>("first", first));

            return TwitchGetGenericAsync<GetBannedEventsResponse>("/moderation/banned/events", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion


    }
}
