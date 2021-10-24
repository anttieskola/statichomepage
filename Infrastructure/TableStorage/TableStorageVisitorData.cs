using Azure;
using Azure.Data.Tables;
using Configuration;
using Microsoft.Extensions.Logging;
using PresentationModels.VisitorDataApplication;
using TableStorage.Entities;

namespace TableStorage
{
    public class TableStorageVisitorData : IStorageVisitorData, IDisposable
    {
        private readonly ILogger<TableStorageVisitorData> _logger;
        private readonly IConfigurationClient _configurationClient;

        public TableStorageVisitorData(
            ILogger<TableStorageVisitorData> logger,
            IConfigurationClient configurationClient)
        {
            _logger = logger;
            _configurationClient = configurationClient;
        }

        public async Task<bool> Store(VisitorProperties visitorProperties)
        {
            var entity = new VisitorPropertiesEntity(visitorProperties);
            var result = await AddEntitiesAsync<VisitorPropertiesEntity>(entity);
            return result;
        }

        private async Task<bool> AddEntitiesAsync<T>(T tableEntity) where T : class, ITableEntity, new()
        {
            _logger.LogTrace($"AddEntitiesAsync<{typeof(T)}>)");

            try
            {
                var tableClient = CreateTableClient(Constants.TableName(tableEntity));
                var az = await tableClient.AddEntityAsync(tableEntity);
                return az.Status >= 200 && az.Status < 300;
            }
            catch (RequestFailedException ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public async Task<VisitorData> QueryData(VisitorProperties data)
        {
            try
            {
                var tableClient = CreateTableClient(Constants.TableName(data));
                var results = tableClient.QueryAsync<VisitorPropertiesEntity>($"PartitionKey eq '{data.IpAddress}:{data.Port}'", 10).AsPages();

                // TODO
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        private async Task<bool> UpdateEntitiesAsync<T>(string tableName, T tableEntity) where T : class, ITableEntity, new()
        {
            _logger.LogTrace($"UpdateEntitiesAsync<{typeof(T)}>({tableName})");

            try
            {
                var tableClient = CreateTableClient(tableName);
                var az = await tableClient.AddEntityAsync(tableEntity);
                return az.Status == 1;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        private TableClient CreateTableClient(string tableName)
        {
#if DEBUG
            return new TableClient(_configurationClient.GetValue("TableStorage-Emulator"), tableName);
#else
            var uri = _configurationClient.GetValue("TableStorage-Uri");
            uri += tableName;
            uri += _configurationClient.GetValue("TableStorage-Sas");
            return new TableClient(new Uri(uri));
#endif
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
