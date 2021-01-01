using System;

namespace Tracket.Common.Exceptions
{
    public class TracketBusinessException : Exception
    {
        public TracketBusinessException()
            : base()
        {

        }

        public TracketBusinessException(string message)
            : base(message)
        {

        }

        public TracketBusinessException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}