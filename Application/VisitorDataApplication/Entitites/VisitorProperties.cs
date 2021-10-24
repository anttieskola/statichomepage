namespace VisitorDataApplication.Entitites
{
    internal record VisitorProperties
    {
        public string Id { get; set; }
        public string IpAddress { get; set; }

        public VisitorProperties(string id, string ipAddress)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            IpAddress = ipAddress ?? throw new ArgumentNullException(nameof(IpAddress));
        }
    }
}
