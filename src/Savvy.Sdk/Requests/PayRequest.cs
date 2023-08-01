namespace Savvy.Sdk.Requests
{
    public class PayRequest : AuthenticatedRequest
    {      
        public required string RequestId { get; set; }
        public required string CardNumber { get; set; }
        public required string Pin { get; set; }
        public required string Currency { get; set; }
        public double Amount { get; set; }
    }
}
