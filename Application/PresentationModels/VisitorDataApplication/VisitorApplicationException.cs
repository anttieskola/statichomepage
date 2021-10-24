using System;

namespace PresentationModels.VisitorDataApplication
{
    public class VisitorApplicationException : Exception
    {
        public VisitorApplicationException(string message)
            : base(message)
        {
        }
    }
}
