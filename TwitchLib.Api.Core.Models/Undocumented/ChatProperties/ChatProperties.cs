using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.ChatProperties
{
    public class ChatProperties
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("hide_chat_links")]
        public bool HideChatLinks { get; set; }
        [JsonPropertyName("chat_delay_duration")]
        public int ChatDelayDuration { get; set; }
        [JsonPropertyName("chat_rules")]
        public string[] ChatRules { get; set; }
        [JsonPropertyName("twitchbot_rule_id")]
        public int TwitchbotRuleId { get; set; }
        [JsonPropertyName("devchat")]
        public bool DevChat { get; set; }
        [JsonPropertyName("game")]
        public string Game { get; set; }
        [JsonPropertyName("subsonly")]
        public bool SubsOnly { get; set; }
        [JsonPropertyName("chat_servers")]
        public string[] ChatServers { get; set; }
        [JsonPropertyName("web_socket_servers")]
        public string[] WebSocketServers { get; set; }
        [JsonPropertyName("web_socket_pct")]
        public double WebSocketPct { get; set; }
        [JsonPropertyName("darklaunch_pct")]
        public double DarkLaunchPct { get; set; }
        [JsonPropertyName("available_chat_notification_tokens")]
        public string[] AvailableChatNotificationTokens { get; set; }
        [JsonPropertyName("sce_title_preset_text_1")]
        public string SceTitlePresetText1 { get; set; }
        [JsonPropertyName("sce_title_preset_text_2")]
        public string SceTitlePresetText2 { get; set; }
        [JsonPropertyName("sce_title_preset_text_3")]
        public string SceTitlePresetText3 { get; set; }
        [JsonPropertyName("sce_title_preset_text_4")]
        public string SceTitlePresetText4 { get; set; }
        [JsonPropertyName("sce_title_preset_text_5")]
        public string SceTitlePresetText5 { get; set; }
    }
}
