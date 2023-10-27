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
                    Scopes.Add(StringToScope(scope.ToString()));
                Token = json["token"].ToString();
                Refresh = json["refresh"].ToString();
                Username = json["username"].ToString();
                ClientId = json["client_id"].ToString();
            }
        }

        private AuthScopes StringToScope(string scope)
        {
            switch (scope)
            {
                case "user_read":
                    return AuthScopes.User_Read;
                case "user_blocks_edit":
                    return AuthScopes.User_Blocks_Edit;
                case "user_blocks_read":
                    return AuthScopes.User_Blocks_Read;
                case "user_follows_edit":
                    return AuthScopes.User_Follows_Edit;
                case "channel_read":
                    return AuthScopes.Channel_Read;
                case "channel_commercial":
                    return AuthScopes.Channel_Commercial;
                case "channel_stream":
                    return AuthScopes.Channel_Subscriptions;
                case "channel_subscriptions":
                    return AuthScopes.Channel_Subscriptions;
                case "user_subscriptions":
                    return AuthScopes.User_Subscriptions;
                case "channel_check_subscription":
                    return AuthScopes.Channel_Check_Subscription;
                case "chat_login":
                    return AuthScopes.Chat_Login;
                case "channel_editor":
                    return AuthScopes.Channel_Editor;
                case "channel_feed_read":
                    return AuthScopes.Channel_Feed_Read;
                case "channel_feed_edit":
                    return AuthScopes.Channel_Feed_Edit;
                case "collections_edit":
                    return AuthScopes.Collections_Edit;
                case "communities_edit":
                    return AuthScopes.Communities_Edit;
                case "communities_moderate":
                    return AuthScopes.Communities_Moderate;
                case "viewing_activity_read":
                    return AuthScopes.Viewing_Activity_Read;
                case "user:edit":
                    return AuthScopes.Helix_User_Edit;
                case "user:read:email":
                    return AuthScopes.Helix_User_Read_Email;
                case "clips:edit":
                    return AuthScopes.Helix_Clips_Edit;
                case "analytics:read:games":
                    return AuthScopes.Helix_Analytics_Read_Games;
                case "bits:read":
                    return AuthScopes.Helix_Bits_Read;
                case "channel:read:subscriptions":
                    return AuthScopes.Helix_Channel_Read_Subscriptions;
                case "channel:read:hype_train":
                    return AuthScopes.Helix_Channel_Read_Hype_Train;
                case "channel:manage:redemptions":
                    return AuthScopes.Helix_Channel_Manage_Redemptions;
                case "channel:edit:commercial":
                    return AuthScopes.Helix_Channel_Edit_Commercial;
                case "channel:read:stream_key":
                    return AuthScopes.Helix_Channel_Read_Stream_Key;
                case "channel:read:editors":
                    return AuthScopes.Helix_Channel_Read_Editors;
                case "channel:manage:videos":
                    return AuthScopes.Helix_Channel_Manage_Videos;
                case "user:read:blocked_users":
                    return AuthScopes.Helix_User_Read_BlockedUsers;
                case "user:manage:blocked_users":
                    return AuthScopes.Helix_User_Manage_BlockedUsers;
                case "user:read:subscriptions":
                    return AuthScopes.Helix_User_Read_Subscriptions;
                case "channel:manage:polls":
                    return AuthScopes.Helix_Channel_Manage_Polls;
                case "channel:manage:predictions":
                    return AuthScopes.Helix_Channel_Manage_Predictions;
                case "channel:read:polls":
                    return AuthScopes.Helix_Channel_Read_Polls;
                case "channel:read:predictions":
                    return AuthScopes.Helix_Channel_Read_Predictions;
                case "moderator:manage:automod":
                    return AuthScopes.Helix_Moderator_Manage_Automod;
                case "":
                    return AuthScopes.None;
                default:
                    throw new Exception("Unknown scope");
            }
        }

    }
}
