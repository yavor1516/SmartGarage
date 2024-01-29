﻿namespace ForumSystem.Responses
{
    public class ErrorResponse
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        // Constructor chaining with the correct syntax
        public ErrorResponse(string errorMessage) : this(new List<string> { errorMessage }) { }

        public ErrorResponse(IEnumerable<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}