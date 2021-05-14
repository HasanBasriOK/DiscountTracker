using System;
namespace DiscountTracker.Entities.Core
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //base : dataresult
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
