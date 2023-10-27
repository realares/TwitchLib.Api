﻿using System;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Core.Common
{
    /// <summary>Static class of helper functions used around the project.</summary>
    public static class Helpers
    {
        /// <summary>
        /// Function that extracts just the token for consistency
        /// </summary>
        /// <param name="token">Full token string</param>
        /// <returns></returns>
        public static string FormatOAuth(string token)
        {
            return token.Contains(" ") ? token.Split(' ')[1] : token;
        }

        public static string AuthScopesToString(AuthScopes scope)
        {
            switch (scope)
            {
                case AuthScopes.Helix_Chat_Read:
                    return "chat:read";
                case AuthScopes.Helix_Chat_Edit:
                    return "chat:edit";
                case AuthScopes.Helix_Channel_Read_Vips:
                    return "channel:read:vips";
                // end neu

  
                case AuthScopes.Helix_User_Edit_Broadcast:
                    return "user:edit:broadcast";
                case AuthScopes.Helix_Analytics_Read_Extensions:
                    return "analytics:read:extensions";
                case AuthScopes.Helix_Analytics_Read_Games:
                    return "analytics:read:games";
                case AuthScopes.Helix_Bits_Read:
                    return "bits:read";
                case AuthScopes.Helix_Channel_Edit_Commercial:
                    return "channel:edit:commercial";
                case AuthScopes.Helix_Channel_Manage_Broadcast:
                    return "channel:manage:broadcast";
                case AuthScopes.Helix_Channel_Manage_Extensions:
                    return "channel:manage:extensions";
                case AuthScopes.Helix_Channel_Manage_Redemptions:
                    return "channel:manage:redemptions";
                case AuthScopes.Helix_Channel_Read_Hype_Train:
                    return "channel:read:hype_train";
                case AuthScopes.Helix_Channel_Read_Redemptions:
                    return "channel:read:redemptions";
                case AuthScopes.Helix_Channel_Read_Stream_Key:
                    return "channel:read:stream_key";
                case AuthScopes.Helix_Channel_Read_Subscriptions:
                    return "channel:read:subscriptions";
                case AuthScopes.Helix_Clips_Edit:
                    return "clips:edit";
                case AuthScopes.Helix_Moderation_Read:
                    return "moderation:read";
                case AuthScopes.Helix_User_Edit:
                    return "user:edit";
                case AuthScopes.Helix_User_Edit_Follows:
                    return "user:edit:follows";
                case AuthScopes.Helix_User_Read_Broadcast:
                    return "user:read:broadcast";
                case AuthScopes.Helix_User_Read_Email:
                    return "user:read:email";
                case AuthScopes.Helix_Channel_Read_Editors:
                    return "channel:read:editors";
                case AuthScopes.Helix_Channel_Manage_Videos:
                    return "channel:manage:videos";
                case AuthScopes.Helix_User_Read_BlockedUsers:
                    return "user:read:blocked_users";
                case AuthScopes.Helix_User_Manage_BlockedUsers:
                    return "user:manage:blocked_users";
                case AuthScopes.Helix_User_Read_Subscriptions:
                    return "user:read:subscriptions";
                case AuthScopes.Helix_Channel_Manage_Polls:
                    return "channel:manage:polls";
                case AuthScopes.Helix_Channel_Manage_Predictions:
                    return "channel:manage:predictions";
                case AuthScopes.Helix_Channel_Manage_Schedule:
                    return "channel:manage:schedule";
                case AuthScopes.Helix_Channel_Read_Goals:
                    return "channel:read:goals";
                case AuthScopes.Helix_Channel_Read_Polls:
                    return "channel:read:polls";
                case AuthScopes.Helix_Channel_Read_Predictions:
                    return "channel:read:predictions";
                case AuthScopes.Helix_Moderator_Manage_Banned_Users:
                    return "moderator:manage:banned_users";
                case AuthScopes.Helix_Moderator_Manage_Blocked_Terms:
                    return "moderator:manage:blocked_terms";
                case AuthScopes.Helix_Moderator_Manage_Automod:
                    return "moderator:manage:automod";
                case AuthScopes.Helix_Moderator_Manage_Automod_Settings:
                    return "moderator:manage:automod_settings";
                case AuthScopes.Helix_Moderator_Manage_Chat_Settings:
                    return "moderator:manage:chat_settings";
                case AuthScopes.Helix_Moderator_Read_Blocked_Terms:
                    return "moderator:read:blocked_terms";
                case AuthScopes.Helix_Moderator_Read_Automod_Settings:
                    return "moderator:read:automod_settings";
                case AuthScopes.Helix_Moderator_Read_Chat_Settings:
                    return "moderator:read:chat_settings";
                case AuthScopes.Helix_User_Read_Follows:
                    return "user:read:follows";
                case AuthScopes.Helix_Moderator_Read_Followers:
                    return "moderator:read:followers";
                case AuthScopes.Any:
                case AuthScopes.None:
                default:
                    return "";
            }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}