using System;

namespace Tracket.Common.Exceptions
{
    public class TracketInternalServerException : Exception
    {
        public TracketInternalServerException()
            : base()
        {

        }

        public TracketInternalServerException(string message)
            : base(message)
        {

        }

        public TracketInternalServerException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}