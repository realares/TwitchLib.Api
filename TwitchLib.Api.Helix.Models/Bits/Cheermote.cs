using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchLib.Api.Helix.Models.Bits
{
    /// <summary>
    /// Cheermotes are animated emotes that viewers can assign Bits to and can be used in any Bits-enabled channel’s chat room.
    /// </summary>
    public record Cheermote
    {
        /// <summary>
        /// <para>The name portion of the Cheermote string that you use in chat to cheer Bits. 
        /// The full Cheermote string is the concatenation of {prefix} + {number of Bits}.</para> 
        /// For example, if the prefix is “Cheer” and you want to cheer 100 Bits, the full Cheermote string is Cheer100. 
        /// When the Cheermote string is entered in chat, Twitch converts it to the image associated with the Bits tier that was cheered.
        /// </summary>
        [JsonPropertyName("prefix")]
        public string Prefix { get; set; } = null!;

        /// <summary>
        /// <para>A list of tier levels that the Cheermote supports.</para>
        /// <para>Each tier identifies the range of Bits that you can cheer at that tier level and an image that graphically identifies the tier level.</para>
        /// </summary>
        [JsonPropertyName("tiers")]
        public Tier[] Tiers { get; set; } = null!;

        /// <summary>
        /// <para>The type of Cheermote. Possible values are:</para>
        /// <para>global_first_party - A Twitch-defined Cheermote that is shown in the Bits card.</para>
        /// <para>global_third_party - A Twitch-defined Cheermote that is not shown in the Bits card. </para>
        /// <para>channel_custom - A broadcaster-defined Cheermote.</para>
        /// <para>display_only - Do not use; for internal use only.</para>
        /// <para>sponsored - A sponsor-defined Cheermote. 
        /// When used, the sponsor adds additional Bits to the amount that the user cheered. 
        /// For example, if the user cheered Terminator100, the broadcaster might receive 110 Bits, which includes the sponsor's 10 Bits contribution.</para>
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// <para>The order that the Cheermotes are shown in the Bits card.</para>
        /// <para>The numbers may not be consecutive. 
        /// For example, the numbers may jump from 1 to 7 to 13.</para>
        /// <para>The order numbers are unique within a Cheermote type (for example, global_first_party) 
        /// but may not be unique amongst all Cheermotes in the response.</para>
        /// </summary>
        [JsonPropertyName("order")]
        public int Order { get; set; }

        /// <summary>
        /// The date and time when this Cheermote was last updated.
        /// </summary>
        [JsonPropertyName("last_updated")]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// A Boolean value that indicates whether this Cheermote provides a charitable contribution match during charity campaigns.
        /// </summary>
        [JsonPropertyName("is_charitable")]
        public bool IsCharitable { get; set; }

    }
}
