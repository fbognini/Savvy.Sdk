using fbognini.Sdk.Interfaces;

namespace Savvy.Sdk
{
    internal class SavvyCurrentUserService : ISdkCurrentUserService
    {
        private readonly string accessToken;

        public SavvyCurrentUserService(int adminTeamId, string merchantId, string accessToken)
        {
            AdminTeamId = adminTeamId;
            MerchantId = merchantId;
            this.accessToken = accessToken;
        }

        public int AdminTeamId { get; }

        public string MerchantId { get; }

        public Task<string> GetAccessToken() => Task.FromResult(accessToken);

        public Task<bool> IsAuthenticated() => Task.FromResult(!string.IsNullOrWhiteSpace(accessToken));

        public Task<string> ReloadAccessToken() => Task.FromResult(accessToken);
    }
}
