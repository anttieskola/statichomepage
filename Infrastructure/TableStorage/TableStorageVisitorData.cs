using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Data.Tables;
using Configuration;
using Microsoft.Extensions.Logging;

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


            var options = new TableClientOptions
            {
            };

            _client = new TableClient(new Uri(configurationClient.GetValue("TableStorage:Uri"), options);
        }


        public Task<NavigatorData> Store(NavigatorData data)
        {
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
