using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Channels.GetChannelEditors;
using TwitchLib.Api.Helix.Models.Channels.GetChannelFollowers;
using TwitchLib.Api.Helix.Models.Channels.GetChannelInformation;
using TwitchLib.Api.Helix.Models.Channels.GetFollowedChannels;
using TwitchLib.Api.Helix.Models.Channels.ModifyChannelInformation;
using System.Text.Json;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;

namespace TwitchLib.Api.Helix
{
    /// <summary>
    /// Channel related APIs
    /// </summary>
    public class Channels : ApiBase
    {
        public Channels(ILogger<Channels> logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) : base(logger, settings, rateLimiter, http)
        {
        }

        #region GetChannelInformation
        /// <summary>
        /// Gets channel information for given user.
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster whose channel you want to get.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns cref="GetChannelInformationResponse"></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<GetChannelInformationResponse?> GetChannelInformationAsync(string broadcasterId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            return TwitchGetGenericAsync<GetChannelInformationResponse>("/channels", ApiVersion.Helix, getParams, accessToken);
        }
        #endregion

        #region ModifyChannelInformation
        /// <summary>
        /// Modifies channel information for given user.
        /// <para>Required scope: channel:manage:broadcast</para>
        /// </summary>
        /// <param name="broadcasterId">ID of the channel to be updated</param>
        /// <param name="request" cref="ModifyChannelInformationRequest"></param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns></returns>
        /// <exception cref="BadParameterException"></exception>
        public async Task<bool> ModifyChannelInformationAsync(string broadcasterId, ModifyChannelInformationRequest request, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            var response = await TwitchPatchAsync("/channels", ApiVersion.Helix, JsonSerializer.Serialize(request), getParams, accessToken);

            // Successfully updated the channel's properties if return code is 204 (No Content)
            return response.Key == System.Net.HttpStatusCode.NoContent;
        }
        #endregion

        #region GetChannelEditors
        /// <summary>
        /// Gets a list of users who have editor permissions for a specific channel.
        /// <para>Required scope: channel:read:editors</para>
        /// </summary>
        /// <param name="broadcasterId">The ID of the broadcaster whose editors you want to get.</param>
        /// <param name="accessToken">optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns cref="GetChannelEditorsResponse"></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<GetChannelEditorsResponse?> GetChannelEditorsAsync(string broadcasterId, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new("broadcaster_id", broadcasterId)
            };

            return TwitchGetGenericAsync<GetChannelEditorsResponse>("/channels/editors", ApiVersion.Helix, getParams, accessToken);
        }
        #endregion

        #region GetFollowedChannels

        /// <summary>
        /// Gets a list of broadcasters that the specified user follows.
        /// <para>You can also use this endpoint to see whether a user follows a specific broadcaster.</para>
        /// </summary>
        /// <param name="userId">
        /// A user’s ID. Returns the list of broadcasters that this user follows.
        /// <para>This ID must match the user ID in the user OAuth token.</para>
        /// </param>
        /// <param name="broadcasterId">
        /// A broadcaster’s ID. Use this parameter to see whether the user follows this broadcaster.
        /// <para>If specified, the response contains this broadcaster if the user follows them.</para>
        /// <para>If not specified, the response contains all broadcasters that the user follows.</para>
        /// </param>
        /// <param name="first"> The maximum number of items to return per page in the response. Min: 1, Max: 100, Default: 20.</param>
        /// <param name="after">The cursor used to get the next page of results</param>
        /// <param name="accessToken"> Optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns cref="GetFollowedChannelsResponse"></returns>
        public Task<GetFollowedChannelsResponse?> GetFollowedChannelsAsync(
            string userId, string? broadcasterId = null, int first = 20, string? after = null, string? accessToken = null)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new BadParameterException("userId must be set");

            if (first < 1 || first > 100)
                throw new BadParameterException("first cannot be less than 1 or greater than 100");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user_id", userId)
            };

            if (!string.IsNullOrWhiteSpace(broadcasterId))
                getParams.Add(new KeyValuePair<string, string>("broadcaster_id", broadcasterId));
            if (first != 20)
                getParams.Add(new KeyValuePair<string, string>("first", first.ToString()));
            if (!string.IsNullOrWhiteSpace(after))
                getParams.Add(new KeyValuePair<string, string>("after", after));

            return TwitchGetGenericAsync<GetFollowedChannelsResponse>("/channels/followed", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region GetChannelFollowers

        /// <summary>
        /// Gets a list of users that follow the specified broadcaster.
        /// <para>You can also use this endpoint to see whether a specific user follows the broadcaster.</para>
        /// </summary>
        /// <permission cref="moderator:read:followers"
        /// <param name="broadcasterId">The broadcaster’s ID. Returns the list of users that follow this broadcaster.</param>
        /// <param name="userId">
        /// A users’s ID. Use this parameter to see whether the user follows this broadcaster.
        /// <para>If specified, the response contains this user if they follow the broadcaster.</para>
        /// <para>If not specified, the response contains all users follow the broadcaster</para>
        /// </param>
        /// <param name="first"> The maximum number of items to return per page in the response. Min: 1, Max: 100, Default: 20.</param>
        /// <param name="after">The cursor used to get the next page of results</param>
        /// <param name="accessToken"> Optional access token to override the use of the stored one in the TwitchAPI instance</param>
        /// <returns cref="GetFollowedChannelsResponse"></returns>
        public Task<GetChannelFollowersResponse?> GetChannelFollowersAsync(
            string broadcasterId, string? userId = null, int first = 20, string? after = null, string? accessToken = null)
        {
            if (string.IsNullOrWhiteSpace(broadcasterId))
                throw new BadParameterException("broadcasterId must be set");

            if (first < 1 || first > 100)
                throw new BadParameterException("first cannot be less than 1 or greater than 100");

            var getParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
            };

            if (!string.IsNullOrWhiteSpace(userId))
                getParams.Add(new KeyValuePair<string, string>("user_id", userId));

            if (first != 20)
                getParams.Add(new KeyValuePair<string, string>("first", first.ToString()));

            if (!string.IsNullOrWhiteSpace(after))
                getParams.Add(new KeyValuePair<string, string>("after", after));

            return TwitchGetGenericAsync<GetChannelFollowersResponse>("/channels/followers", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion
    }
}