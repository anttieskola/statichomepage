using Azure.Data.Tables;
using Configuration;
using Microsoft.Extensions.Logging;
using PresentationModels.VisitorDataApplication;

namespace TableStorage
{
    public class TableStorageVisitorData : IStorageVisitorData, IDisposable
    {
        private readonly ILogger<TableStorageVisitorData> _logger;
        private readonly IConfigurationClient _configurationClient;
        private readonly TableClient _clientNavigatorProps;

        public TableStorageVisitorData(
            ILogger<TableStorageVisitorData> logger,
            IConfigurationClient configurationClient)
        {
            _logger = logger;
            _configurationClient = configurationClient;
        }

        public async Task<NavigatorProperties> Store(NavigatorProperties data)
        {
            _logger.LogTrace("TableStorageVisitorData: Store");

            await AddEntitiesAsync<NavigatorProperties>("NavigatorProperties", data);
        }


        private async Task AddEntitiesAsync<T>(string tableName, T tableEntity) where T : class, ITableEntity, new()
        {
            try
            {
                var TableClient = CreateaAuthenticatedTableClient(tableName);
                await TableClient.AddEntityAsync(tableEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private TableClient CreateaAuthenticatedTableClient(string tableName)
        {
            var uri = _configurationClient.GetValue("TableStorage-Uri");
            uri += tableName;
            uri += _configurationClient.GetValue("TableStorage-Sas");
            return new TableClient(new Uri(uri));
        }

        #region IDisposable
        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~TableStorageVisitorData()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);

        }
        #endregion IDisposable
    }
}
