using System;
namespace DiscountTracker.Entities.Dto
{
    public class GetMyProductsRequest:IRequest
    {
        public string UserId { get; set; }
    }
}
