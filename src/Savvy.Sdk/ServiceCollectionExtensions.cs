using fbognini.Sdk.Extensions;
using fbognini.Sdk.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Savvy.Sdk
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSavvyApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SavvyApiSettings>(configuration.GetSection(nameof(SavvyApiSettings)));

            services.AddHttpClient<ISavvyApiService, SavvyApiService>()
                .ThrowApiExceptionIfNotSuccess()
                .AddLogging();

            return services;
        }
    }
}
