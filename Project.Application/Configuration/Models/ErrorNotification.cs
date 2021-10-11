using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Application.Configuration.Models
{
    public class ErrorNotification
    {
        private readonly List<Error> _errors = new List<Error>();

        public void AddError(string message)
        {
            AddError(message, null);
        }

        public void AddError(string message, Exception e)
        {
            _errors.Add(new Error(message, e));
        }

        public string ErrorMessage()
        {
            return string.Join(",", _errors.Select(x => x.Message));
        }

        public bool HasErrors()
        {
            return _errors.Any();
        }
    }
}
