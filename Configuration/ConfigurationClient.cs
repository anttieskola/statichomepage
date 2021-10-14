using System;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Logging;

namespace Configuration
{
    public class ConfigurationClient : IConfigurationClient
    {
        private readonly ILogger<ConfigurationClient> _logger;
        private readonly SecretClient _client;

        public ConfigurationClient(
            ILogger<ConfigurationClient> logger)
        {
            _logger = logger;

            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(15),
                    MaxRetries = 1,
                    Mode = RetryMode.Fixed
                 }
            };

            _client = new SecretClient(new Uri("https://omatsivut.vault.azure.net/"), 
                new DefaultAzureCredential(), options);
        }

        public string GetValue(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }

            try
            {
                KeyVaultSecret secret = _client.GetSecret(name, null);
                _logger.LogTrace("secret retrieved successfully"); 
                return secret.Value;
            }
            catch (RequestFailedException exception)
            {
                _logger.LogError("keyvault get failed", exception);
                throw;
            }
        }
    }
}
