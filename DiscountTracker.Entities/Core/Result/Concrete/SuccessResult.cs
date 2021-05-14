using System;
namespace DiscountTracker.Entities.Core
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }


        public SuccessResult() : base(true)
        {
        }
    }
}
