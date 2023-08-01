using System.Text.Json.Serialization;

namespace Savvy.Sdk.Models
{
    public class RefundResponse : BaseModel
    {
        [JsonPropertyName("expiryDate")]
        public string? ExpiryDate { get; set; }
        [JsonPropertyName("startDate")]
        public string? StartDate { get; set; }
        [JsonPropertyName("isFirstResponse")]
        public bool? IsFirstResponse { get; set; }
    }
}
