using System;

namespace Tracket.Common.Exceptions
{
    public class TracketNotFoundException : Exception
    {
        public TracketNotFoundException()
            : base()
        {

        }

        public TracketNotFoundException(string message)
            : base(message)
        {

        }

        public TracketNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}