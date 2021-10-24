using PresentationModels.VisitorDataApplication;

namespace TableStorage
{
    public interface IStorageVisitorData
    {
        Task<bool> Store(VisitorProperties data);
        Task<VisitorData> QueryData(VisitorProperties data);
    }
}
