using System;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.Entities.Dto
{
    public class LoginResponse:IResponse
    {
        public LoginResponse()
        {
        }

        public DtUser User { get; set; }
    }
}
