using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api.Core.Enums;
using TwitchLib.Api.Core.Exceptions;
using TwitchLib.Api.Core.Interfaces;
using TwitchLib.Api.Core.Internal;

namespace TwitchLib.Api.Core.HttpCallHandlers
{
    public class TwitchHttpClient : IHttpCallHandler
    {
        private readonly ILogger<TwitchHttpClient> _logger;
        private readonly HttpClient _http;

        /// <summary>
        /// Creates an Instance of the TwitchHttpClient Class.
        /// </summary>
        /// <param name="logger">Instance Of Logger, otherwise no logging is used,  </param>
        public TwitchHttpClient(ILogger<TwitchHttpClient> logger)
        {
            _logger = logger;
            _http = new HttpClient(new TwitchHttpClientHandler(_logger));
        }


        public async Task PutBytesAsync(string url, byte[] payload)
        {
            var response = await _http.PutAsync(new Uri(url), new ByteArrayContent(payload)).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                HandleWebException(response);
        }

        public async Task<KeyValuePair<HttpStatusCode, string?>> GeneralRequestAsync(
            string url, string method,
            string? payload = null, ApiVersion api = ApiVersion.Helix, 
            string? clientId = null, string? accessToken = null)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = new HttpMethod(method)
            };

            if (api == ApiVersion.Helix)
            {
                if (string.IsNullOrWhiteSpace(clientId) || string.IsNullOrWhiteSpace(accessToken))
                    throw new InvalidCredentialException("A Client-Id and OAuth token is required to use the Twitch API.");

                request.Headers.Add("Client-ID", clientId);
            }

            var authPrefix = "OAuth";
            if (api == ApiVersion.Helix || api == ApiVersion.Auth)
            {
                request.Headers.Add(HttpRequestHeader.Accept.ToString(), "application/json");
                authPrefix = "Bearer";
            }

            if (!string.IsNullOrWhiteSpace(accessToken))
                request.Headers.Add(HttpRequestHeader.Authorization.ToString(), $"{authPrefix} {Common.Helpers.FormatOAuth(accessToken)}");

            if (payload != null)
                request.Content = new StringContent(payload, Encoding.UTF8, "application/json");

            var response = await _http.SendAsync(request).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var respStr = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return new KeyValuePair<HttpStatusCode, string?>(response.StatusCode, respStr);
            }

            string error = await response.Content.ReadAsStringAsync();

            //if (handleErrorResults)
            //{
            //    HandleWebException(response, error);
            //    return new KeyValuePair<HttpStatusCode, string?>(0, null);
            //}
            //else
            return new KeyValuePair<HttpStatusCode, string?>(response.StatusCode, error);
            
        }

        public async Task<int> RequestReturnResponseCodeAsync(string url, string method, List<KeyValuePair<string, string>>? getParams = null)
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

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url),
                Method = new HttpMethod(method)
            };
            var response = await _http.SendAsync(request).ConfigureAwait(false);
            return (int)response.StatusCode;
        }

        internal void HandleWebException(HttpResponseMessage errorResp, string? realerror = null)
        {
            switch (errorResp.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    if (realerror != null)
                        throw new BadRequestException(realerror);

                    throw new BadRequestException("Your request failed because either: \n 1. Your ClientID was invalid/not set. \n 2. Your refresh token was invalid. \n 3. You requested a username when the server was expecting a user ID.");
                
                case HttpStatusCode.Unauthorized:
                    if (realerror != null)
                        throw new UnauthorizedRequestException(realerror);

                    var authenticateHeader = errorResp.Headers.WwwAuthenticate;
                    if (authenticateHeader == null || authenticateHeader.Count <= 0)
                        throw new BadScopeException("Your request was blocked due to bad credentials (Do you have the right scope for your access token?).");
                    else
                        throw new TokenExpiredException("Your request was blocked due to an expired Token. Please refresh your token and update your API instance settings.");
                
                case HttpStatusCode.NotFound:
                    if (realerror != null)
                        throw new BadResourceException(realerror);
                    throw new BadResourceException("The resource you tried to access was not valid.");

                case (HttpStatusCode)425: // Too Early
                    throw new TooEarlyException(realerror ?? "Too Early");
                
                case (HttpStatusCode)429: // Too Many Requests
                    errorResp.Headers.TryGetValues("Ratelimit-Reset", out var resetTime);
                    throw new TooManyRequestsException(realerror ?? "" + " - You have reached your rate limit. Too many requests were made", resetTime.FirstOrDefault());

                case HttpStatusCode.BadGateway:
                    if (realerror != null)
                        throw new BadResourceException(realerror);
                    throw new BadGatewayException("The API answered with a 502 Bad Gateway. Please retry your request");
                
                case HttpStatusCode.GatewayTimeout:
                    throw new GatewayTimeoutException("The API answered with a 504 Gateway Timeout. Please retry your request");
                
                case HttpStatusCode.InternalServerError:
                    throw new InternalServerErrorException("The API answered with a 500 Internal Server Error. Please retry your request");
                
                case HttpStatusCode.Forbidden:
                    if (realerror != null)
                        throw new BadTokenException(realerror);
                    throw new BadTokenException("The token provided in the request did not match the associated user. Make sure the token you're using is from the resource owner (streamer? viewer?)");
                
                default:
                    if (realerror != null)
                        throw new HttpRequestException(realerror);

                    throw new HttpRequestException("Something went wrong during the request! Please try again later");
            }
        }

    }
}