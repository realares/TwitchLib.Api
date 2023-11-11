using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.Entitlements.UpdateDropsEntitlements
{
    public record UpdateDropsEntitlementsResponse
    {
        [JsonPropertyName("data")]
        public DropEntitlementUpdate[] DropEntitlementUpdates { get; set; }
    }
}