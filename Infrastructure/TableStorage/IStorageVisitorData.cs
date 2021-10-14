namespace TableStorage
{
    public interface IStorageVisitorData
    {
        Task<NavigatorData> Store(NavigatorData data);
    }
}
