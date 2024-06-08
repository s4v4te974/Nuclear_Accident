using System;

namespace BrokenArrow.Exceptions
{
    public class BrokenArrowException : Exception
    {
        public BrokenArrowException(string message, Exception exception) : base(message, exception) { }

    }
}
