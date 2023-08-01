using System.Text.Json.Serialization;

namespace Savvy.Sdk.Models
{
    public class PayResponse : BaseModel
    {
        [JsonPropertyName("isFirstResponse")]
        public bool? IsFirstResponse { get; set; }
    }
}
