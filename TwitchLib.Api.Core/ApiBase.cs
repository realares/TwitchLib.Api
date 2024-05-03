using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.Models;


namespace TwitchLib.Api.Core
{
    public class ApiBase
    {
        protected readonly ILogger logger;
        protected readonly IApiSettings Settings;
        private readonly IRateLimiter _rateLimiter;
        private readonly IHttpCallHandler _http;

        internal const string BaseHelix = "https://api.twitch.tv/helix";
        internal const string BaseAuth = "https://id.twitch.tv/oauth2";

        private DateTime? _serverBasedAccessTokenExpiry;
        private string? _serverBasedAccessToken = null;

        protected readonly System.Text.Json.JsonSerializerOptions _ms_twitchLibJsonDeserializer;
   
        public ApiBase(ILogger logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
        {
            this.logger = logger;
            Settings = settings;
            _rateLimiter = rateLimiter;
            _http = http;

            _ms_twitchLibJsonDeserializer = new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async ValueTask<string?> GetAccessTokenAsync(string? accessToken = null)
        {
            if (!string.IsNullOrEmpty(accessToken))
                return accessToken;
            if (!string.IsNullOrEmpty(Settings.AccessToken))
                return Settings.AccessToken;
            if (!string.IsNullOrEmpty(Settings.Secret) && !string.IsNullOrEmpty(Settings.ClientId) && !Settings.SkipAutoServerTokenGeneration)
            {
                if (_serverBasedAccessTokenExpiry == null || _serverBasedAccessTokenExpiry - TimeSpan.FromMinutes(1) < DateTime.Now)
                    return await GenerateServerBasedAccessToken().ConfigureAwait(false);

                return _serverBasedAccessToken;
            }

            return null;
        }

        internal async Task<string?> GenerateServerBasedAccessToken()
        {
            var result = await _http.GeneralRequestAsync($"{BaseAuth}/token?client_id={Settings.ClientId}&client_secret={Settings.Secret}&grant_type=client_credentials", "POST", null, ApiVersion.Auth, Settings.ClientId, null).ConfigureAwait(false);
            if (result.Key ==  HttpStatusCode.OK)
            {
                var user = System.Text.Json.JsonSerializer.Deserialize<TokeResult>(result.Value);
                //var user = JsonConvert.DeserializeObject<dynamic>(result.Value);
                if (user == null) return null;
                var offset = (int)user.Expires_in;
                _serverBasedAccessTokenExpiry = DateTime.Now + TimeSpan.FromSeconds(offset);
                _serverBasedAccessToken = (string)user.Access_token;
                return _serverBasedAccessToken;
            }
            return null;
        }
        class TokeResult
        {
            [JsonPropertyName("access_token")]
            public string Access_token { get; set; } = null!;

            [JsonPropertyName("expires_in")]
            public int Expires_in { get; set; } 

            [JsonPropertyName("token_type")]
            public string Token_type { get; set; } = null!;
        }

        internal void ForceAccessTokenAndClientIdForHelix(string? clientId, string? accessToken, ApiVersion api)
        {
            if (api != ApiVersion.Helix)
                return;
            if (!string.IsNullOrWhiteSpace(clientId) && !string.IsNullOrWhiteSpace(accessToken))
                return;
            throw new ClientIdAndOAuthTokenRequired("As of May 1, all calls to Twitch's Helix API require Client-ID and OAuth access token be set. Example: api.Settings.AccessToken = \"twitch-oauth-access-token-here\"; api.Settings.ClientId = \"twitch-client-id-here\";");
        }

        protected async Task<T?> Twitch__GenericAsync<T>(
            string methode,
            string resource, ApiVersion api, 
            string? payload = null, 
            List<KeyValuePair<string, string>>? getParams = null,
            string? accessToken = null, 
            string? clientId = null, 
            string? customBase = null,
            bool throwExceptions = true)
        {
            var url = ConstructResourceUrl(resource, getParams, api, customBase);

            if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
                clientId = Settings.ClientId;

            accessToken = await GetAccessTokenAsync(accessToken).ConfigureAwait(false);
            ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);

            return await _rateLimiter
                .Perform(async () => {
                    var httpresult = (await _http.GeneralRequestAsync(url, methode, payload, api, clientId, accessToken).ConfigureAwait(false));
                    return HandleResponse<T>(httpresult, throwExceptions);

                }).ConfigureAwait(false);
        }

        protected Task<T?> TwitchGetGenericAsync<T>(
            string resource, ApiVersion api, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, string? clientId = null, string? customBase = null,
            bool throwExceptions = true)
        {
            return Twitch__GenericAsync<T>("GET", resource, api, null, getParams, accessToken, clientId, customBase, throwExceptions);
        }

        protected Task<T?> TwitchPatchGenericAsync<T>(
            string resource, ApiVersion api, string payload, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, string? clientId = null, string? customBase = null,
            bool throwExceptions = true)
        {
            return Twitch__GenericAsync<T>("PATCH", resource, api, payload, getParams, accessToken, clientId, customBase, throwExceptions);
        }

        protected Task<T?> TwitchPostGenericAsync<T>(
            string resource, ApiVersion api, string? payload = null, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, string? clientId = null, string? customBase = null,
            bool throwExceptions = true)
        {
            return Twitch__GenericAsync<T>("POST", resource, api, payload, getParams, accessToken, clientId, customBase, throwExceptions);
        }

        protected Task<T?> TwitchDeleteGenericAsync<T>(
            string resource, ApiVersion api, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, string? clientId = null, string? customBase = null,
            bool throwExceptions = true)
        {
            return Twitch__GenericAsync<T>("DELETE", resource, api, null, getParams, accessToken, clientId, customBase, throwExceptions);
        }

        protected Task<T?> TwitchPutGenericAsync<T>(
            string resource, ApiVersion api, string payload, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, string? clientId = null, string? customBase = null,
            bool throwExceptions = true)
        {
            return Twitch__GenericAsync<T>("PUT", resource, api, payload, getParams, accessToken, clientId, customBase, throwExceptions);
        }

        protected async Task<KeyValuePair<HttpStatusCode, string>> Twitch__Async(
            string methode, 
            string resource, ApiVersion api, string? payload = null, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, string? clientId = null, string? customBase = null)
        {
            var url = ConstructResourceUrl(resource, getParams, api, customBase);

            if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
                clientId = Settings.ClientId;

            accessToken = await GetAccessTokenAsync(accessToken).ConfigureAwait(false);
            ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);

            return await _rateLimiter
                .Perform(async () => (await _http.GeneralRequestAsync(url, methode, payload, api, clientId, accessToken)
                .ConfigureAwait(false)))
                .ConfigureAwait(false);
        }

        protected Task<KeyValuePair<HttpStatusCode, string>> TwitchGetAsync(string resource, ApiVersion api, 
            List<KeyValuePair<string, string>>? getParams = null, string? accessToken = null, string? clientId = null, string? customBase = null)
        {
            return Twitch__Async("GET", resource, api, null, getParams, accessToken, clientId, customBase);
        }

        protected Task<KeyValuePair<HttpStatusCode, string>> TwitchPatchAsync(string resource, ApiVersion api, string? payload, 
            List<KeyValuePair<string, string>>? getParams = null, string? accessToken = null, string? clientId = null, string? customBase = null)
        {
            return Twitch__Async("PATCH", resource, api, payload, getParams, accessToken, clientId, customBase);
        }

        protected Task<KeyValuePair<HttpStatusCode, string>> TwitchDeleteAsync(string resource, ApiVersion api, 
            List<KeyValuePair<string, string>>? getParams = null, string? accessToken = null, string? clientId = null, string? customBase = null)
        {
            return Twitch__Async("DELETE", resource, api, null, getParams, accessToken, clientId, customBase);
        }

        protected Task<KeyValuePair<HttpStatusCode, string>> TwitchPostAsync(string resource, ApiVersion api, 
            string? payload, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, string? clientId = null, string? customBase = null)
        {
            return Twitch__Async("POST", resource, api, payload, getParams, accessToken, clientId, customBase);
        }

        protected Task<KeyValuePair<HttpStatusCode, string>> TwitchPutAsync(string resource, ApiVersion api, 
            string? payload, List<KeyValuePair<string, string>>? getParams = null, string? accessToken = null, string? clientId = null, string? customBase = null)
        {
            return Twitch__Async("PUT", resource, api, payload, getParams, accessToken, clientId, customBase);
        }

        protected async Task<T?> TwitchPostGenericModelAsync<T>(string resource, ApiVersion api, 
            Object model, string? accessToken = null, string? clientId = null, string? customBase = null)
        {
            var url = ConstructResourceUrl(resource, api: api, overrideUrl: customBase);

            if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
                clientId = Settings.ClientId;

            accessToken = await GetAccessTokenAsync(accessToken).ConfigureAwait(false);
            ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);

            return await _rateLimiter.Perform(async () =>
                {
                    var payload = model != null ? System.Text.Json.JsonSerializer.Serialize(model) : "";
                    var httpresult = (await _http.GeneralRequestAsync(url, "POST", payload, api, clientId, accessToken).ConfigureAwait(false)).Value;
                    return System.Text.Json.JsonSerializer.Deserialize<T>(httpresult, _ms_twitchLibJsonDeserializer);
                });
                //=> JsonConvert.DeserializeObject<T>((await _http.GeneralRequestAsync(url, "POST", model != null ? _jsonSerializer.SerializeObject(model) : "", api, clientId, accessToken).ConfigureAwait(false)).Value, _twitchLibJsonDeserializer)).ConfigureAwait(false);
        }


        protected Task PutBytesAsync(string url, byte[] payload)
        {
            return _http.PutBytesAsync(url, payload);
        }

        internal Task<int> RequestReturnResponseCode(string url, string method, List<KeyValuePair<string, string>>? getParams = null)
        {
            return _http.RequestReturnResponseCodeAsync(url, method, getParams);
        }

        protected async Task<T?> GetGenericAsync<T>(
            string url, List<KeyValuePair<string, string>>? getParams = null, 
            string? accessToken = null, ApiVersion api = ApiVersion.Helix, string? clientId = null)
        {
            if (getParams != null)
            {
                for (var i = 0; i < getParams.Count; i++)
                {
                    if (i == 0)
                        url += $"?{getParams[i].Key}={Uri.EscapeDataString(getParams[i].Value)}";
                    else
                        url += $"&{getParams[i].Key}={Uri.EscapeDataString(getParams[i].Value)}";
                }
            }

            if (string.IsNullOrEmpty(clientId) && !string.IsNullOrEmpty(Settings.ClientId))
                clientId = Settings.ClientId;

            accessToken = await GetAccessTokenAsync(accessToken).ConfigureAwait(false);
            ForceAccessTokenAndClientIdForHelix(clientId, accessToken, api);

            return await _rateLimiter.Perform(async () =>
            {
                var httpresult = (await _http.GeneralRequestAsync(url, "GET", null, api, clientId, accessToken).ConfigureAwait(false)).Value;
                return System.Text.Json.JsonSerializer.Deserialize<T>(httpresult, _ms_twitchLibJsonDeserializer);
            });
        }

        internal Task<T?> GetSimpleGenericAsync<T>(string url, List<KeyValuePair<string, string>>? getParams = null)
        {
            if (getParams != null)
            {
                for (var i = 0; i < getParams.Count; i++)
                {
                    if (i == 0)
                        url += $"?{getParams[i].Key}={Uri.EscapeDataString(getParams[i].Value)}";
                    else
                        url += $"&{getParams[i].Key}={Uri.EscapeDataString(getParams[i].Value)}";
                }
            }
            return _rateLimiter.Perform(async () =>
            {
                var httpresult = (await SimpleRequestAsync(url).ConfigureAwait(false));
                return System.Text.Json.JsonSerializer.Deserialize<T>(httpresult, _ms_twitchLibJsonDeserializer);
            });
        }

        private async Task<string> SimpleRequestAsync(string url)
        {
            using var httpClient = new HttpClient();

            var getresponse = await httpClient.GetStringAsync(url).ConfigureAwait(false);

            return getresponse;
        }

        private string ConstructResourceUrl(
            string? resource = null, 
            List<KeyValuePair<string, string>>? getParams = null, 
            ApiVersion api = ApiVersion.Helix, 
            string? overrideUrl = null)
        {
            var url = "";
            if (overrideUrl == null)
            {
                if (resource == null)
                    throw new Exception("Cannot pass null resource with null override url");
                switch (api)
                {
                    case ApiVersion.Helix:
                        url = $"{BaseHelix}{resource}";
                        break;
                    case ApiVersion.Auth:
                        url = $"{BaseAuth}{resource}";
                        break;
                }
            }
            else
            {
                url = resource == null ? overrideUrl : $"{overrideUrl}{resource}";
            }
            if (getParams != null)
            {
                for (var i = 0; i < getParams.Count; i++)
                {
                    if (i == 0)
                        url += $"?{getParams[i].Key}={Uri.EscapeDataString(getParams[i].Value)}";
                    else
                        url += $"&{getParams[i].Key}={Uri.EscapeDataString(getParams[i].Value)}";
                }
            }
            return url;
        }

        protected T? HandleResponse<T>(KeyValuePair<HttpStatusCode, string> webresult, bool throwExceptions)
        {
            switch (webresult.Key)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.NoContent:
                    return JsonSerializer.Deserialize<T>(webresult.Value, _ms_twitchLibJsonDeserializer); 

                case HttpStatusCode.BadRequest:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new BadRequestException(webresult.Value);
                    return default;

                case HttpStatusCode.Unauthorized:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new UnauthorizedRequestException(webresult.Value);
                    return default; 

                // The ID in the broadcaster_id query parameter must match the user ID in the access token.
                case HttpStatusCode.Forbidden:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new BadTokenException(webresult.Value);
                    return default;

                case HttpStatusCode.NotFound:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new NotFoundRequestException(webresult.Value);
                    return default;

                case HttpStatusCode.Conflict:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new ConflictRequestException(webresult.Value);
                    return default;

                case HttpStatusCode.UnprocessableEntity:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new UnprocessableEntityRequestException(webresult.Value);
                    return default;

                case (HttpStatusCode)425: // Too Early
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new TooEarlyException(webresult.Value);
                    return default;

                case (HttpStatusCode)429: // Too Many Requests
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new TooManyRequestsException(webresult.Value, "");
                    return default;

                default:
                    logger.LogError(webresult.Value); 
                    if (throwExceptions) throw new Exception(webresult.Value);
                    return default;
            }
        }

        protected bool HandleBooleanResponse(KeyValuePair<HttpStatusCode, string> webresult, bool throwExceptions)
        {
            switch (webresult.Key)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.NoContent:
                    return true;

                case HttpStatusCode.BadRequest:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new BadRequestException(webresult.Value);
                    return false;

                case HttpStatusCode.Unauthorized:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new UnauthorizedRequestException(webresult.Value);
                    return false;

                // The ID in the broadcaster_id query parameter must match the user ID in the access token.
                case HttpStatusCode.Forbidden:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new BadTokenException(webresult.Value);
                    return false;

                case HttpStatusCode.NotFound:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new NotFoundRequestException(webresult.Value);
                    return false;

                case HttpStatusCode.Conflict:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new ConflictRequestException(webresult.Value);
                    return false;

                case HttpStatusCode.UnprocessableEntity:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new UnprocessableEntityRequestException(webresult.Value);
                    return false;

                case (HttpStatusCode)425: // Too Early
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new TooEarlyException(webresult.Value);
                    return false;

                case (HttpStatusCode)429: // Too Many Requests
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new TooManyRequestsException(webresult.Value, "");
                    return false;

                default:
                    logger.LogError(webresult.Value);
                    if (throwExceptions) throw new Exception(webresult.Value);
                    return false;
            }
        }
    }
}
