using System;
using System.Text.Json.Serialization;

namespace TwitchLib.Api.Core.Models.Undocumented.TwitchPrimeOffers
{
    public class Offer
    {
        [JsonPropertyName("applicableGame")]
        public string ApplicableGame { get; set; }
        [JsonPropertyName("assets")]
        public Asset[] Assets { get; set; }
        [JsonPropertyName("contentCategories")]
        public string[] ContentCategories { get; set; }
        [JsonPropertyName("contentClaimInstructions")]
        public string ContentClaimInstruction { get; set; }
        [JsonPropertyName("contentDeliveryMethod")]
        public string ContentDeliveryMethod { get; set; }
        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }
        [JsonPropertyName("offerDescription")]
        public string OfferDescription { get; set; }
        [JsonPropertyName("offerId")]
        public string OfferId { get; set; }
        [JsonPropertyName("offerTitle")]
        public string OfferTitle { get; set; }
        [JsonPropertyName("priority")]
        public int Priority { get; set; }
        [JsonPropertyName("publisherName")]
        public string PublisherName { get; set; }
        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }
    }
}
