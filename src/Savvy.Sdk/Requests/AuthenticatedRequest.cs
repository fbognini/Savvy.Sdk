namespace Savvy.Sdk.Requests
{
    public class AuthenticatedRequest
    {
        public int AdminTeamId { get; private set; }
        public string? MerchantId { get; private set; }

        internal void AuthenticateRequest(SavvyCurrentUserService currentUserService)
        {
            AdminTeamId = currentUserService.AdminTeamId;
            MerchantId = currentUserService.MerchantId;
        }
    }
}
