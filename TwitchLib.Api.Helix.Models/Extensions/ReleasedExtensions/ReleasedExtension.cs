using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Helix.Models.Extensions.ReleasedExtensions
{
    public class ReleasedExtension
    {
        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; }
        [JsonPropertyName("bits_enabled")]
        public bool BitsEnabled { get; set; }
        [JsonPropertyName("can_install")]
        public bool CanInstall { get; set; }
        [JsonPropertyName("configuration_location")]
        public string ConfigurationLocation { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("eula_tos_url")]
        public string EulaTosUrl { get; set; }
        [JsonPropertyName("has_chat_support")]
        public bool HasChatSupport { get; set; }
        [JsonPropertyName("icon_url")]
        public string IconUrl { get; set; }
        [JsonPropertyName("icon_urls")]
        public IconUrls IconUrls { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("privacy_policy_url")]
        public string PrivacyPolicyUrl { get; set; }
        [JsonPropertyName("request_identity_link")]
        public bool RequestIdentityLink { get; set; }
        [JsonPropertyName("screenshot_urls")]
        public string[] ScreenshotUrls { get; set; }
        [JsonPropertyName("state")]
        public ExtensionState State { get; set; }
        [JsonPropertyName("subscriptions_support_level")]
        public string SubscriptionsSupportLevel { get; set; }
        [JsonPropertyName("summary")]
        public string Summary { get; set; }
        [JsonPropertyName("support_email")]
        public string SupportEmail { get; set; }
        [JsonPropertyName("version")]
        public string Version { get; set; }
        [JsonPropertyName("viewer_summary")]
        public string ViewerSummary { get; set; }
        [JsonPropertyName("views")]
        public Views Views { get; set; }
        [JsonPropertyName("allowlisted_config_urls")]
        public string[] AllowlistedConfigUrls { get; set; }
        [JsonPropertyName("allowlisted_panel_urls")]
        public string[] AllowlistedPanelUrls { get; set; }
    }
}
