using System;
namespace DiscountTracker.Entities.Dto
{
    public class CreateUserRequest:IRequest
    {
        public CreateUserRequest()
        {
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string DeviceId { get; set; }
    }
}
