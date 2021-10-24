using PresentationModels.VisitorDataApplication;

namespace VisitorDataApplication
{
    public interface IVisitorDataApplication
    {
        Task<VisitorData> NewVisitorAsync(VisitorProperties visitorProperties);
    }
}
