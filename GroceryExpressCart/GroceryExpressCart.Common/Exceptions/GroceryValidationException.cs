using System;

namespace GroceryExpressCart.Common.Exceptions
{
    public class GroceryValidationException : BaseException
    {
        private const string _empty = "";
        public string Details { get; }
        public GroceryValidationException(string message, string details = _empty) : base(message) =>
            Details = details;
        public GroceryValidationException()
        {
        }
        public GroceryValidationException(string message) : base(message)
        {
        }
        public GroceryValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GroceryValidationException(string message, params object[] args) : base(message, args)
        {
        }

        protected GroceryValidationException(string code, string message, params object[] args) : base(code, message, args)
        {
        }

        protected GroceryValidationException(Exception innerException, string message, params object[] args) : base(innerException, message, args)
        {
        }

        protected GroceryValidationException(Exception innerException, string code, string message, params object[] args) : base(innerException, code, message, args)
        {
        }
    }
}
