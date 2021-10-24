using System;

namespace PresentationModels.VisitorDataApplication
{
    public class VisitorProperties
    {
        /// <summary>
        /// Visitors unique id
        /// </summary>
        public string UniqueId { get; set; }

        public VisitorProperties(string connectionInfoId, string ipAddress, int port)
        {
            UniqueId = Guid.NewGuid().ToString();
            ConnectionInfoId = connectionInfoId ?? throw new ArgumentNullException(nameof(connectionInfoId));
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(ipAddress));
            Port = port;
        }

        /// <summary>
        /// Connection info id
        /// </summary>
        public string ConnectionInfoId { get; set; }

        /// <summary>
        /// Public ip address
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// Public port used
        /// </summary>
        public int Port { get; set; }
    }
}
