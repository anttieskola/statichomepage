using Azure.Data.Tables;
using Configuration;
using Microsoft.Extensions.Logging;
using PresentationModels.VisitorDataApplication;

namespace TableStorage
{
    public class TableStorageVisitorData : IStorageVisitorData, IDisposable
    {
        private readonly ILogger<TableStorageVisitorData> _logger;
        private readonly TableClient _client;

        public TableStorageVisitorData(
            ILogger<TableStorageVisitorData> logger,
            IConfigurationClient configurationClient)
        {
            _logger = logger;
            _client = new TableClient(new Uri(configurationClient.GetValue("TableStorage:Uri")));

        }

        public Task<NavigatorProperties> Store(NavigatorProperties data)
        {
            throw new NotImplementedException();
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
