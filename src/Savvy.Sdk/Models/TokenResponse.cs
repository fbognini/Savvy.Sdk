using System.Text.Json.Serialization;

namespace Savvy.Sdk.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("authenticated")]
        public bool Authenticated { get; set; }
        [JsonPropertyName("returnCode")]
        public int ReturnCode { get; set; }

        [JsonPropertyName("responseText")]
        public required string ResponseText { get; set; }

        [JsonPropertyName("token")]
        public string? Token { get; set; }

        [JsonPropertyName("token_expiry")]
        public DateTime? TokenExpiration { get; set; }
    }
}
