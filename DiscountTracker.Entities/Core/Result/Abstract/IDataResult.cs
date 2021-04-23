using System;
namespace DiscountTracker.Entities.Core
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
