using System;

namespace Project.Application.Configuration.Models
{
    public class Error
    {
        public string Message { get; set; }
        public Exception Cause { get; set; }

        public Error(string message, Exception cause)
        {
            Message = message;
            Cause = cause;
        }
    }
}
