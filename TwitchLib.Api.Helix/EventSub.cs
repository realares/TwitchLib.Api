using System.Text.Json.Serialization;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status">Filter subscriptions by its status. </param>
        /// <param name="type">Filter subscriptions by subscription type. For a list of subscription types, see Subscription Types.</param>
        /// <param name="user_id">Filter subscriptions by user ID. 
        /// The response contains subscriptions where this ID matches a user ID that you specified in the Condition object when you created the subscription.</param>
        /// <param name="after"></param>
        /// <param name="clientId"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public Task<GetEventSubSubscriptionsResponse?> GetEventSubSubscriptionsAsync(
            EventSubStatus? status = null, 
            string? type = null, 
            string? user_id = null,
            string? after = null, 
            string? clientId = null, string? accessToken = null)
        {
            var getParams = new List<KeyValuePair<string, string>>();

            if (status != null)
                getParams.Add(new("status", status.Value.ToString()));

            if (!string.IsNullOrWhiteSpace(user_id))
                getParams.Add(new("user_id", user_id));

            if (!string.IsNullOrWhiteSpace(type))
                getParams.Add(new("type", type));

            if (!string.IsNullOrWhiteSpace(after))
                getParams.Add(new("after", after));

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

    /// <summary>
    /// Repräsentiert die möglichen Statuswerte einer EventSub-Subscription bei Twitch.
    /// </summary>
    public enum EventSubStatus
    {
        /// <summary>
        /// Twitch hat Ihren Callback verifiziert und kann Ihnen Benachrichtigungen senden.
        /// </summary>
        enabled,

        /// <summary>
        /// Twitch überprüft derzeit, ob Sie den im Erstellungsauftrag angegebenen Callback besitzen.
        /// Wird nur für Webhook-Subscriptions verwendet.
        /// </summary>
        webhook_callback_verification_pending,

        /// <summary>
        /// Twitch konnte nicht verifizieren, dass Sie den im Erstellungsauftrag angegebenen Callback besitzen.
        /// Beheben Sie das Problem in Ihrem Event-Handler und versuchen Sie erneut zu abonnieren.
        /// Wird nur für Webhook-Subscriptions verwendet.
        /// </summary>
        webhook_callback_verification_failed,

        /// <summary>
        /// Die Anzahl der Benachrichtigungsfehler hat ein akzeptables Maß überschritten.
        /// Twitch hat Ihre Subscription deaktiviert.
        /// </summary>
        notification_failures_exceeded,

        /// <summary>
        /// Die Autorisierung, die für die Subscription verwendet wurde, wurde widerrufen oder ist ungültig.
        /// Aktualisieren Sie das Autorisierungstoken und abonnieren Sie erneut.
        /// </summary>
        authorization_revoked,

        moderator_removed,

        /// <summary>
        /// Der Benutzer, auf den sich die Subscription bezieht, existiert nicht mehr.
        /// </summary>
        user_removed,

        /// <summary>
        /// The user specified in the Condition object was banned from the broadcaster's chat.
        /// </summary>
        chat_user_banned,

        /// <summary>
        /// The subscription to subscription type and version is no longer supported.
        /// </summary>
        version_removed,

        beta_maintenance,
        websocket_disconnected,
        websocket_failed_ping_pong,
        websocket_received_inbound_traffic,
        websocket_connection_unused,
        websocket_internal_error,
        websocket_network_timeout,
        websocket_network_error,
        websocket_failed_to_reconnect
    }
}
