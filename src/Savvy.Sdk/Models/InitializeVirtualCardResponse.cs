using System.Text.Json.Serialization;

namespace Savvy.Sdk.Models
{
    public class InitializeVirtualCardResponse : BaseModel
    {
        [JsonPropertyName("pin")]
        public required string Pin { get; set; }
    }
}
