using Azure;
using Azure.Data.Tables;
using PresentationModels.VisitorDataApplication;

namespace TableStorage.Entities
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/azure/storage/tables/table-storage-design-patterns#index-entities-pattern
    /// The Table service automatically indexes your entities using the PartitionKey and RowKey values in a single clustered index,
    /// hence the reason that point queries are the most efficient to use. However, there are no indexes other than that on the
    /// clustered index on the PartitionKey and RowKey.
    /// 
    /// You can handle the consistency issue by using EGTs to update multiple entities in a single atomic transaction.
    /// 
    /// An entity can have up to 255 properties, including 3 system properties described in
    /// the following section. Therefore, the user may include up to 252 custom properties,
    /// in addition to the 3 system properties. The combined size of all data in an entity's
    /// properties cannot exceed 1 MiB.
    /// </summary>
    internal class VisitorPropertiesEntity : ITableEntity
    {
#pragma warning disable CS8618 // Just to satisfy api
        public VisitorPropertiesEntity()
#pragma warning restore CS8618 // Just to satisfy api
        {
            // don't use
        }

        internal VisitorPropertiesEntity(VisitorProperties visitorProperties)
        {
            RowKey = visitorProperties.UniqueId;
            PartitionKey = $"{visitorProperties.IpAddress}:{visitorProperties.Port}";
            ConnectionInfoId = visitorProperties.ConnectionInfoId;
        }

        public string ConnectionInfoId { get; set; }

        public string PartitionKey { get; set; }
        public string RowKey { get; set; }

        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

    }
}
