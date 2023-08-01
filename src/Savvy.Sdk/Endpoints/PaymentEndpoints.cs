namespace Savvy.Sdk.Endpoints
{
    public static class PaymentEndpoints
    {
        public static string GetBalance() => $"balance";
        public static string InitializeVirtualCard() => $"initializevirtualcard";
        public static string Redeem() => $"redeem";
        public static string Refund() => $"refund";
    }
}
