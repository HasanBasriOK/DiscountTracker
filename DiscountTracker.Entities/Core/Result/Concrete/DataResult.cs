using System;
namespace DiscountTracker.Entities.Core
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult()
        {
        }

        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
