using fbognini.Sdk;
using fbognini.Sdk.Interfaces;
using fbognini.Sdk.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Savvy.Sdk;
using Savvy.Sdk.Models;
using Savvy.Sdk.Requests;
using Savvy.Sdk.Endpoints;
using System.Net.Http.Headers;

namespace Savvy.Sdk
{
    public interface ISavvyApiPaymentService
    {
        Task<TokenResponse> Authenticate(GetTokenRequest request);
        Task<TokenResponse> GetToken(GetTokenRequest request);
        Task<InitializeVirtualCardResponse> InitializeVirtualCard(InitializeVirtualCardRequest request);
        Task<BalanceResponse> ValidatePromoCode(ValidatePromoCodeRequest request);
        Task<PayResponse> Pay(PayRequest request);
        Task<RefundResponse> Refund(RefundRequest request);
    }

    internal class SavvyApiPaymentService : BaseApiService, ISavvyApiPaymentService
    {
        private readonly SavvyApiSettings settings;
        private new SavvyCurrentUserService? currentUserService;

        public SavvyApiPaymentService(HttpClient client, ILogger<SavvyApiPaymentService> logger, IOptions<SavvyApiSettings> options)
            : base(client, logger, httpErrorHandler: null, currentUserService: null)
        {
            this.settings = options.Value;

            client.BaseAddress = new Uri(settings.ApiUrl);
            client.DefaultRequestHeaders.Add("Connect-Direct-Subscription-Key", settings.SubscriptionKey);
        }

        public async Task<TokenResponse> Authenticate(GetTokenRequest request)
        {
            var tokenResponse = await GetToken(request);
            if (tokenResponse.Authenticated)
            {
                this.currentUserService = new SavvyCurrentUserService(request.AdminTeamId, request.MerchantId, tokenResponse.Token!);
                base.currentUserService = this.currentUserService;
            }

            return tokenResponse;
        }

        public async Task<TokenResponse> GetToken(GetTokenRequest request)
        {
            var uurca = await PostApi<GetTokenRequest>(AuthenticationEndpoints.GetToken(), request);

            return await PostApi<TokenResponse, GetTokenRequest>(AuthenticationEndpoints.GetToken(), request);
        }

        public async Task<BalanceResponse> ValidatePromoCode(ValidatePromoCodeRequest request)
        {
            var options = new RequestOptions()
            {
                Headers = new Dictionary<string, IEnumerable<string>>
                {
                    ["ActivatingMID-ON"] = new[] { "true" }
                }
            };

            request.AuthenticateRequest(currentUserService!);

            return await PostApi<BalanceResponse, ValidatePromoCodeRequest>(PaymentEndpoints.GetBalance(), request, options);
        }

        public async Task<InitializeVirtualCardResponse> InitializeVirtualCard(InitializeVirtualCardRequest request)
        {
            var options = new RequestOptions()
            {
                Headers = new Dictionary<string, IEnumerable<string>>
                {
                    ["ActivatingMID-ON"] = new[] { "true" }
                }
            };

            request.AuthenticateRequest(currentUserService!);

            return await PostApi<InitializeVirtualCardResponse, InitializeVirtualCardRequest>(PaymentEndpoints.InitializeVirtualCard(), request, options);
        }

        public async Task<PayResponse> Pay(PayRequest request)
        {
            request.AuthenticateRequest(currentUserService!);
            return await PostApi<PayResponse, PayRequest>(PaymentEndpoints.Redeem(), request);
        }

        public async Task<RefundResponse> Refund(RefundRequest request)
        {
            request.AuthenticateRequest(currentUserService!);

            return await PostApi<RefundResponse, RefundRequest>(PaymentEndpoints.Refund(), request);
        }
    }
}
