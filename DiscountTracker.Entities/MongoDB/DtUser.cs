using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtUser : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsApproved { get; set; }
        public bool IsActive { get; set; }
        public string DeviceId { get; set; }
    }
}
