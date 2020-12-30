using System;

namespace Tracket.Common.Exceptions
{
    public class TracketBadRequestException : Exception
    {
        public TracketBadRequestException()
            : base()
        {

        }

        public TracketBadRequestException(string message)
            : base(message)
        {

        }

        public TracketBadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}