using System;

namespace SmartGarage.Exceptions
{
    public class InvalidUserInputException : ApplicationException
    {
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}
