using System;
namespace DiscountTracker.Entities.Dto
{
    public class LoginRequest:IRequest
    {
        public LoginRequest()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
