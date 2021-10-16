using PresentationModels.VisitorDataApplication;

namespace VisitorDataApplication
{
    public interface IVisitorDataApplication
    {
        Task<NavigatorProperties> Store(NavigatorProperties navigationProperties);
    }
}
