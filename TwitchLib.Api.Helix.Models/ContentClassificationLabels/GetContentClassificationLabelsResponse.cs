using System.Text.Json.Serialization;

namespace TwitchLib.Api.Helix.Models.ContentClassificationLabels
{
   /// <summary>
   /// Response from GetContentClassificationLabels which gets information about Twitch content classification labels.
   /// </summary>
   public record GetContentClassificationLabelsResponse
   {
      /// <summary>
      /// A list that contains information about the available content classification labels.
      /// </summary>
      [JsonPropertyName("data")]
      public ContentClassificationLabel[] Data { get; set; } = null!;
    }
}
