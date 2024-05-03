using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;
using TwitchLib.Api.Core;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Events;
using TwitchLib.Api.ThirdParty.AuthorizationFlow;
using TwitchLib.Api.ThirdParty.ModLookup;
using TwitchLib.Api.ThirdParty.UsernameChange;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using TwitchLib.Api.Helix;

namespace TwitchLib.Api.ThirdParty
{
    /// <summary>These endpoints are offered by third party services (NOT TWITCH), but are still pretty cool.</summary>
    public class ThirdParty
    {
        public ThirdParty(ILogger<ThirdParty> logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http)
        {
            UsernameChange = new UsernameChangeApi(logger, settings, rateLimiter, http);
            ModLookup = new ModLookupApi(logger, settings, rateLimiter, http);
            AuthorizationFlow = new AuthorizationFlowApi(logger, settings, rateLimiter, http);
        }

        public UsernameChangeApi UsernameChange { get; }
        public ModLookupApi ModLookup { get; }
        public AuthorizationFlowApi AuthorizationFlow { get; }

        public class UsernameChangeApi : ApiBase
        {
            public UsernameChangeApi(ILogger logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) : base(logger, settings, rateLimiter, http)
            {
            }

            #region GetUsernameChanges

            public Task<List<UsernameChangeListing>> GetUsernameChangesAsync(string username)
            {
                var getParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("q", username),
                    new KeyValuePair<string, string>("format", "json")
                };

                return GetGenericAsync<List<UsernameChangeListing>>("https://twitch-tools.rootonline.de/username_changelogs_search.php", getParams, null, ApiVersion.Void);
            }

            #endregion
        }

        public class ModLookupApi : ApiBase
        {
            public ModLookupApi(ILogger logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) : base(logger, settings, rateLimiter, http)
            {
            }

            public Task<ModLookupResponse> GetChannelsModdedForByNameAsync(string username, int offset = 0, int limit = 100, bool useTls12 = true)
            {
                if (useTls12)
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                var getParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("offset", offset.ToString()),
                    new KeyValuePair<string, string>("limit", limit.ToString())
                };
                return GetGenericAsync<ModLookupResponse>($"https://twitchstuff.3v.fi/modlookup/api/user/{username}", getParams, null, ApiVersion.Void);
            }

            public Task<TopResponse> GetChannelsModdedForByTopAsync(bool useTls12 = true)
            {
                if (useTls12)
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                return GetGenericAsync<TopResponse>("https://twitchstuff.3v.fi/modlookup/api/top");
            }

            public Task<StatsResponse> GetChannelsModdedForStatsAsync(bool useTls12 = true)
            {
                if (useTls12)
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                return GetGenericAsync<StatsResponse>("https://twitchstuff.3v.fi/modlookup/api/stats");
            }
        }

        public class AuthorizationFlowApi : ApiBase
        {
            private const string BaseUrl = "https://twitchtokengenerator.com/api";
            private string _apiId;
            private Timer _pingTimer;

            public AuthorizationFlowApi(ILogger logger, IApiSettings settings, IRateLimiter rateLimiter, IHttpCallHandler http) : base(logger, settings, rateLimiter, http)
            {
            }

            public event EventHandler<OnUserAuthorizationDetectedArgs> OnUserAuthorizationDetected;
            public event EventHandler<OnAuthorizationFlowErrorArgs> OnError;

            public async Task<CreatedFlow> CreateFlowAsync(string applicationTitle, IEnumerable<AuthScopes> scopes)
            {
                string scopesStr = null;
                foreach (var scope in scopes)
                    if (scopesStr == null)
                        scopesStr = Core.Common.Helpers.AuthScopesToString(scope);
                    else
                        scopesStr += $"+{Core.Common.Helpers.AuthScopesToString(scope)}";

                var createUrl = $"{BaseUrl}/create/{Core.Common.Helpers.Base64Encode(applicationTitle)}/{scopesStr}";

                using var client = new HttpClient();
                string resp = await client.GetStringAsync(createUrl).ConfigureAwait(false);
                return JsonSerializer.Deserialize<CreatedFlow>(resp);
            }

            public async Task<RefreshTokenResponse> RefreshTokenAsync(string refreshToken)
            {
                var refreshUrl = $"{BaseUrl}/refresh/{refreshToken}";

                using var client = new HttpClient();
                var resp = await client.GetStringAsync(refreshUrl).ConfigureAwait(false); 
                return JsonSerializer.Deserialize<RefreshTokenResponse>(resp);
            }

            public void BeginPingingStatus(string id, int intervalMs = 5000)
            {
                _apiId = id;
                _pingTimer = new Timer(intervalMs);
                _pingTimer.Elapsed += OnPingTimerElapsed;
                _pingTimer.Start();
            }

            public async Task<PingResponse> PingStatusAsync(string id = null)
            {
                if (id != null)
                    _apiId = id;

                using var client = new HttpClient();
                var resp = await client.GetStringAsync($"{BaseUrl}/status/{_apiId}").ConfigureAwait(false);
                var model = new PingResponse(resp);

                return model;
            }

            private async void OnPingTimerElapsed(object sender, ElapsedEventArgs e)
            {
                var ping = await PingStatusAsync();
                if (ping.Success)
                {
                    _pingTimer.Stop();
                    OnUserAuthorizationDetected?.Invoke(null, new OnUserAuthorizationDetectedArgs
                    {
                        Id = ping.Id,
                        Scopes = ping.Scopes,
                        Token = ping.Token,
                        Username = ping.Username,
                        Refresh = ping.Refresh,
                        ClientId = ping.ClientId
                    });
                }
                else
                {
                    if (ping.Error == 3) return;

                    _pingTimer.Stop();
                    OnError?.Invoke(null, new OnAuthorizationFlowErrorArgs {Error = ping.Error, Message = ping.Message});
                }
            }
        }
    }
}