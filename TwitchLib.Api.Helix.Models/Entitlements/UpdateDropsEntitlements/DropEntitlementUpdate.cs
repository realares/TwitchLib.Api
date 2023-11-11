using System.Text.Json.Serialization;
using TwitchLib.Api.Core.Enums;

namespace TwitchLib.Api.Helix.Models.Entitlements.UpdateDropsEntitlements
{
    public record DropEntitlementUpdate
    {
        [JsonConverter(typeof(System.Text.Json.Serialization.JsonStringEnumConverter))]
        [JsonPropertyName("status")]
        public DropEntitlementUpdateStatus Status { get; set; }

        [JsonPropertyName("ids")]
        public string[] Ids { get; set; }
    }
}