using PresentationModels.VisitorDataApplication;

namespace VisitorDataApplication;

public class VisitorDataApplication : IVisitorDataApplication
{
    public VisitorDataApplication()
    {

    }


    public Task<NavigatorProperties> Store(NavigatorProperties navigationProperties)
    {
        throw new NotImplementedException();
    }
}
