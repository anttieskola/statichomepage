using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Logging;

namespace Configuration
{
    /// <summary>
    /// ConfigurationClient using Azure KeyVault secrets
    /// </summary>
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
                    Delay= TimeSpan.FromSeconds(1),
                    MaxDelay = TimeSpan.FromSeconds(2),
                    MaxRetries = 2,
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

            var cts = new CancellationTokenSource();

            try
            {
                // Max timeout
                cts.CancelAfter(TimeSpan.FromSeconds(30));
                KeyVaultSecret secret = _client.GetSecret(name, null, cts.Token);

                _logger.LogTrace("secret get ok"); 
                return secret.Value;
            }
            catch (RequestFailedException exception)
            {
                _logger.LogError("secret get failed", exception);
                throw;
            }
            finally
            {
                _logger.LogError("secret get was timeouted");
                cts.Dispose();
            }
        }
    }
}
