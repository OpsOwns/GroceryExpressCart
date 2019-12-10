using System;
using System.Diagnostics.Contracts;

namespace GroceryExpressCart.Common.Entity
{
    public class Result
    {
        public bool Success { get; }
        public string Error { get; }
        public bool Failure => !Success;
        protected Result(bool success, string error)
        {
            Success = success;
            Error = error;
        }
        public static Result Fail(string message) => new Result(false, message);
        public static Result<T> Fail<T>(string message) => new Result<T>(default, false, message);
        public static Result<T> FailEmpty<T>(string message, T value) => new Result<T>(value, false, message);
        public static Result Ok() => new Result(true, string.Empty);
        public static Result<T> Ok<T>(T value) => new Result<T>(value, true, string.Empty);
        public static Result Combine(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.Failure)
                    return result;
            }
            return Ok();
        }
    }
    public class Result<T> : Result
    {
        private T _value;
        public T Value
        {
            get
            {
                Contract.Requires(Success);
                return _value;
            }
            private set { _value = value; }
        }
        protected internal Result(T value, bool success, string error)
            : base(success, error)
        {
            Contract.Requires(value != null || !success);
            Value = value;
        }
    }
}
