using System;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.Entities.Dto
{
    public class CreateUserResponse:IResponse
    {
        public DtUser User { get; set; }
    }
}
