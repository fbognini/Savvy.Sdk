using System.Text.Json.Serialization;

namespace Savvy.Sdk.Models
{
    public class BaseModel
    {
        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }
       
        [JsonPropertyName("responseText")]
        public string? ResponseText { get; set; }

        /// <summary>
        /// The promo code's current value
        /// </summary>
        /// <value>The promo code's current value</value>
        [JsonPropertyName("balance")]
        public double? Balance { get; set; }

        [JsonPropertyName("amount")]
        public double? Amount { get; set; }

        [JsonPropertyName("merchantId")]
        public required string MerchantId { get; set; }

        [JsonPropertyName("cardNumber")]
        public required string CardNumber { get; set; }
        
        /// <summary>
        /// The promo code's ISO curency code
        /// </summary>
        /// <value>The promo code's ISO curency code</value>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        [JsonPropertyName("authCode")]
        /// <summary>
        /// The AuthCode provided to Confirm/Void the reservation
        /// </summary>
        /// <value>The AuthCode provided to Confirm/Void the reservation</value>
        public int? AuthCode { get; set; }


        [JsonPropertyName("requestId")]
        public string? RequestId { get; set; }

    }
}
