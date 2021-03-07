using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.Dto
{
    public class ApiError
    {
        public string ErrorMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorType { get; set; }
    }
}
