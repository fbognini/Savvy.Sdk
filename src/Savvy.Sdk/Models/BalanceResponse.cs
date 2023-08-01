using System.Text.Json.Serialization;

namespace Savvy.Sdk.Models
{
    public class BalanceResponse : BaseModel
    {


        [JsonPropertyName("pin")]
        /// <summary>
        /// The promo code pin number.
        /// </summary>
        /// <value>The promo code pin number.</value>
        public string? Pin { get; set; }
        [JsonPropertyName("activatingMID")]
        public string? ActivatingMid { get; set; }

    }
}
