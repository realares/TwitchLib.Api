using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api.Helix.Models.ChannelPoints.UpdateCustomReward;

namespace TwitchLib.Api.Helix.Models.ChannelPoints
{
    public class CustomReward
    {
        [JsonPropertyName("broadcaster_id")]
        public string BroadcasterId { get; set; }

        [JsonPropertyName("broadcaster_login")]
        public string BroadcasterLogin { get; set; }

        [JsonPropertyName("broadcaster_name")]
        public string BroadcasterName { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("cost")]
        public int Cost { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("default_image")]
        public DefaultImage DefaultImage { get; set; }

        [JsonPropertyName("background_color")]
        public string BackgroundColor { get; set; }

        [JsonPropertyName("is_enabled")]
        public bool IsEnabled { get; set; }

        [JsonPropertyName("is_user_input_required")]
        public bool IsUserInputRequired { get; set; }

        [JsonPropertyName("max_per_stream_setting")]
        public MaxPerStreamSetting MaxPerStreamSetting { get; set; }

        [JsonPropertyName("max_per_user_per_stream_setting")]
        public MaxPerUserPerStreamSetting MaxPerUserPerStreamSetting { get; set; }

        [JsonPropertyName("global_cooldown_setting")]
        public GlobalCooldownSetting GlobalCooldownSetting { get; set; }

        [JsonPropertyName("is_paused")]
        public bool IsPaused { get; set; }

        [JsonPropertyName("is_in_stock")]
        public bool IsInStock { get; set; }

        [JsonPropertyName("should_redemptions_skip_request_queue")]
        public bool ShouldRedemptionsSkipQueue { get; set; }

        [JsonPropertyName("redemptions_redeemed_current_stream")]
        public int? RedemptionsRedeemedCurrentStream { get; set; }

        [JsonPropertyName("cooldown_expires_at")]
        public string CooldownExpiresAt { get; set; }

        //[JsonPropertyName("global_cooldown_seconds")]
        //public int? GlobalCooldownSeconds { get; set; }

        public CreateCustomReward.CreateCustomRewardsRequest CreateCustomRewardsRequest()
        {
            return new CreateCustomReward.CreateCustomRewardsRequest()
            {
                BackgroundColor = this.BackgroundColor,
                Cost = this.Cost,
                GlobalCooldownSeconds = this.GlobalCooldownSetting.GlobalCooldownSeconds,
                IsGlobalCooldownEnabled = this.GlobalCooldownSetting.IsEnabled,
                IsEnabled = this.IsEnabled,

                IsMaxPerStreamEnabled = this.MaxPerStreamSetting.IsEnabled,
                MaxPerStream = this.MaxPerStreamSetting.MaxPerStream,

                IsMaxPerUserPerStreamEnabled = this.MaxPerUserPerStreamSetting.IsEnabled,
                MaxPerUserPerStream = this.MaxPerUserPerStreamSetting.MaxPerUserPerStream,

                IsUserInputRequired = this.IsUserInputRequired,
                Prompt = this.Prompt,
                Title = this.Title

            };
        }
        public UpdateCustomRewardRequest UpdateCustomRewardsRequest()
        {
            return new UpdateCustomRewardRequest()
            {
                BackgroundColor = this.BackgroundColor,
                Cost = this.Cost,
                GlobalCooldownSeconds = this.GlobalCooldownSetting.GlobalCooldownSeconds,
                IsGlobalCooldownEnabled = this.GlobalCooldownSetting.IsEnabled,
                IsEnabled = this.IsEnabled,

                IsMaxPerStreamEnabled = this.MaxPerStreamSetting.IsEnabled,
                MaxPerStream = this.MaxPerStreamSetting.MaxPerStream,

                IsMaxPerUserPerStreamEnabled = this.MaxPerUserPerStreamSetting.IsEnabled,
                MaxPerUserPerStream = this.MaxPerUserPerStreamSetting.MaxPerUserPerStream,

                IsUserInputRequired = this.IsUserInputRequired,
                Prompt = this.Prompt,
                Title = this.Title

            };
        }
    }
}
