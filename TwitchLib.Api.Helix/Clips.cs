using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Extensions.System;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.Clips.CreateClip;
using TwitchLib.Api.Helix.Models.Clips.GetClips;

namespace TwitchLib.Api.Helix
{
    public class Clips : ApiBase
    {
        public Clips(ILogger<Clips> logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) : base(logger, settings, rateLimiter, http)
        { }

        #region GetClips

        /// <summary>
        /// Gets one or more video clips that were captured from streams. For information about clips, see How to use clips.
        /// </summary>
        /// <param name="clipIds"></param>
        /// <param name="gameId"></param>
        /// <param name="broadcasterId"></param>
        /// <param name="before">
        /// The cursor used to get the previous page of results. 
        /// The Pagination object in the response contains the cursor’s value.</param>
        /// <param name="after">
        /// The cursor used to get the next page of results. 
        /// The Pagination object in the response contains the cursor’s value.</param>
        /// <param name="startedAt"></param>
        /// <param name="endedAt"></param>
        /// <param name="first">
        /// The maximum number of clips to return per page in the response. 
        /// The minimum page size is 1 clip per page and the maximum is 100. 
        /// The default is 20.</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        /// <exception cref="BadParameterException"></exception>
        public Task<GetClipsResponse?> GetClipsAsync(
            List<string>? clipIds = null, string? gameId = null, 
            string? broadcasterId = null, string? before = null, string? after = null, 
            DateTime? startedAt = null, DateTime? endedAt = null, int first = 20, string? accessToken = null)
        {
            if (first < 0 || first > 100)
                throw new BadParameterException("'first' must between 0 (inclusive) and 100 (inclusive).");

            var getParams = new List<KeyValuePair<string, string>>();
            if (clipIds != null)
            {
                foreach(var clipId in clipIds)
                {
                    getParams.Add(new KeyValuePair<string, string>("id", clipId));
                }
            }
            if (gameId != null)
                getParams.Add(new KeyValuePair<string, string>("game_id", gameId));
            if (broadcasterId != null)
                getParams.Add(new KeyValuePair<string, string>("broadcaster_id", broadcasterId));

            if (getParams.Count == 0 || (getParams.Count > 1 && gameId != null && broadcasterId != null))
                throw new BadParameterException("One of the following parameters must be set: clipId, gameId, broadcasterId. Only one is allowed to be set.");

            if (startedAt == null && endedAt != null)
                throw new BadParameterException("The ended_at parameter cannot be used without the started_at parameter. Please include both parameters!");

            if (startedAt != null)
                getParams.Add(new KeyValuePair<string, string>("started_at", startedAt.Value.ToRfc3339String()));
            if (endedAt != null)
                getParams.Add(new KeyValuePair<string, string>("ended_at", endedAt.Value.ToRfc3339String()));
            if (before != null)
                getParams.Add(new KeyValuePair<string, string>("before", before));
            if (after != null)
                getParams.Add(new KeyValuePair<string, string>("after", after));
            getParams.Add(new KeyValuePair<string, string>("first", first.ToString()));

            return TwitchGetGenericAsync<GetClipsResponse>("/clips", ApiVersion.Helix, getParams, accessToken);
        }

        #endregion

        #region CreateClip

        public Task<CreatedClipResponse?> CreateClipAsync(string broadcasterId, string? accessToken = null)
        {
            var getParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("broadcaster_id", broadcasterId)
                };
            return TwitchPostGenericAsync<CreatedClipResponse>("/clips", ApiVersion.Helix, null, getParams, accessToken);
        }

        #endregion

    }
}