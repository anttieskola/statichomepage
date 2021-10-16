using PresentationModels.VisitorDataApplication;

namespace TableStorage
{
    public interface IStorageVisitorData
    {
        Task<NavigatorProperties> Store(NavigatorProperties data);
    }
}
