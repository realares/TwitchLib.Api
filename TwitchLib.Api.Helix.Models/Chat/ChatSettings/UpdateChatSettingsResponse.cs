using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Chat.ChatSettings
{
    public class UpdateChatSettingsResponse
    {
        [JsonPropertyName("data")]
        public UpdateChatSettingsResponseModel[] Data { get; set; }
    }
}
