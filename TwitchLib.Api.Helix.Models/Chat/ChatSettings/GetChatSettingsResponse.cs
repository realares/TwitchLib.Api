using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Chat.ChatSettings
{
    public record GetChatSettingsResponse
    {
        [JsonPropertyName("data")]
        public ChatSettingsResponseModel[] Data { get; set; } = null!;
    }
}
