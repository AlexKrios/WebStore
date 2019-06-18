using System;

namespace CQS.Exceptions
{
    public class ExpiredTokenException : Exception
    {
        public ExpiredTokenException(string message) : base(message)
        {
        }
    }
}
