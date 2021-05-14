using System;
namespace DiscountTracker.Entities.Core
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(true, message)
        {
        }


        public ErrorResult() : base(false)
        {
        }
    }
}
