﻿using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Helix.Models.EventSub;
using System.Text.Json;
using System.Net;
using Microsoft.Extensions.Logging;

namespace TwitchLib.Api.Helix
{
    public class EventSub : ApiBase
    {
        public EventSub(ILogger<EventSub> logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) 
            : base(logger, settings, rateLimiter, http)
        {
        }

        public Task<CreateEventSubSubscriptionResponse?> CreateEventSubSubscriptionAsync(
            string type, string version, Dictionary<string, string> condition, string method, string callback,
            string secret, string? clientId = null, string? accessToken = null)
        {
            if (string.IsNullOrEmpty(type))
                throw new BadParameterException("type must be set");
            if (string.IsNullOrEmpty(version))
                throw new BadParameterException("version must be set");
            if (secret == null || secret.Length < 10 || secret.Length > 100)
                throw new BadParameterException("secret must be set, and be between 10 (inclusive) and 100 (inclusive)");

            var body = new
            {
                type,
                version,
                condition,
                transport = new
                {
                    method,
                    callback,
                    secret
                }
            };

            return TwitchPostGenericAsync<CreateEventSubSubscriptionResponse>("/eventsub/subscriptions", ApiVersion.Helix, JsonSerializer.Serialize(body), null, accessToken, clientId);
        }

        public Task<GetEventSubSubscriptionsResponse?> GetEventSubSubscriptionsAsync(
            string? status = null, string? type = null, string? after = null, string? clientId = null, string? accessToken = null)
        {
            var getParams = new List<KeyValuePair<string, string>>();

            if (!string.IsNullOrWhiteSpace(status))
                getParams.Add(new KeyValuePair<string, string>("status", status));
            if (!string.IsNullOrWhiteSpace(type))
                getParams.Add(new KeyValuePair<string, string>("type", type));
            if (!string.IsNullOrWhiteSpace(after))
                getParams.Add(new KeyValuePair<string, string>("after", after));

            return TwitchGetGenericAsync<GetEventSubSubscriptionsResponse>("/eventsub/subscriptions", ApiVersion.Helix, getParams, accessToken, clientId);
        }

        public async Task<bool> DeleteEventSubSubscriptionAsync(
            string id, string? clientId = null, string? accessToken = null)
        {
            var getParams = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("id", id) };

            var response = await TwitchDeleteAsync("/eventsub/subscriptions", ApiVersion.Helix, getParams, accessToken, clientId);

            return response.Key == HttpStatusCode.NoContent;
        }
    }
}
