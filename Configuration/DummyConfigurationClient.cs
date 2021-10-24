using System;

namespace Configuration
{
    /// <summary>
    /// ConfigurationClient for use in local development
    /// </summary>
    public class DummyConfigurationClient : IConfigurationClient
    {
        public string GetValue(string name)
        {
            return name switch
            {
                "TableStorage-Emulator" => "UseDevelopmentStorage=true",
                _ => throw new ArgumentException($"Not secret value defined for:{name }"),
            };
        }
    }
}
