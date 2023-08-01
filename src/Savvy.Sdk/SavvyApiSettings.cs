using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savvy.Sdk
{
    public enum SavvyApiEnvironment
    {
        STG, PRD
    }

    internal class SavvyEnvironment
    {
        public static SavvyEnvironment STAGING = new(SavvyApiEnvironment.STG, "https://api.savvyconnectdirect.net/sandbox/api/v1/");
        public static SavvyEnvironment PRODUCTION = new(SavvyApiEnvironment.PRD, "https://api.savvyconnectdirect.net/api/v1/");

        public SavvyApiEnvironment EnvironmentName { get; private set; }
        public string ApiUrl { get; private set; }

        private SavvyEnvironment(
            SavvyApiEnvironment environmentName,
            string apiUrl)
        {
            EnvironmentName = environmentName;
            ApiUrl = apiUrl;
        }

        /// <summary>
        /// Generates a configured Environment for use in a ExpediaRapid Gateway; targeted by Environment name.
        /// </summary>
        /// <param name="environment">The name of the target Environment (not case-sensitive)</param>
        /// <returns>A new configured instance of a ExpediaRapid Environment</returns>
        public static SavvyEnvironment ParseEnvironment(SavvyApiEnvironment environment)
        {
            return environment switch
            {
                SavvyApiEnvironment.STG => STAGING,
                SavvyApiEnvironment.PRD => PRODUCTION,
                _ => throw new ArgumentException("Unsupported environment: " + environment),
            };
        }
    }

    public class SavvyApiSettings
    {
        internal SavvyEnvironment Environment => SavvyEnvironment.ParseEnvironment(EnvironmentName);
        public SavvyApiEnvironment EnvironmentName { get; set; }

        internal string ApiUrl => Environment.ApiUrl;

        public required string SubscriptionKey { get; set; }
    }
}
