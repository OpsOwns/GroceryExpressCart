using System;

namespace GroceryExpressCart.Common.CustomException
{
    public class GroceryException : BaseException
    {
        public GroceryException()
        {
        }

        public GroceryException(string code) : base(code)
        {
        }

        public GroceryException(string message, params object[] args) : base(string.Empty, message, args)
        {
        }

        public GroceryException(string code, string message, params object[] args) : base(null, code, message, args)
        {
        }

        public GroceryException(Exception innerException, string message, params object[] args)
            : base(innerException, string.Empty, message, args)
        {
        }

        public GroceryException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
        }

        protected GroceryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
