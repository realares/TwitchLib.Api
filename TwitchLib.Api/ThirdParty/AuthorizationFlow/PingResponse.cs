using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.ThirdParty.AuthorizationFlow
{
    public class PingResponse
    {
        public bool Success { get; set; }
        public string Id { get; set; }

        public int Error { get; set; }
        public string Message { get; set; }

        public List<AuthScopes> Scopes { get; set; }
        public string Token { get; set; }
        public string Refresh { get; set; }
        public string Username { get; set; }
        public string ClientId { get; set; }

        public PingResponse(string jsonStr)
        {
            var json = JsonObject.Parse(jsonStr);
            var doc = JsonDocument.Parse(jsonStr);
          
            Success = bool.Parse(json["success"].ToString());
            if (!Success)
            {
                Error = int.Parse(json["error"].ToString());
                Message = json["message"].ToString();
            } else
            {
                Scopes = new List<AuthScopes>();
                foreach (var scope in json["scopes"].AsArray())
                    Scopes.Add(Core.Common.Helpers.StringToScope(scope.ToString()));
                Token = json["token"].ToString();
                Refresh = json["refresh"].ToString();
                Username = json["username"].ToString();
                ClientId = json["client_id"].ToString();
            }
        }

    
    }
}
