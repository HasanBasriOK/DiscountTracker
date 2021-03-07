using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities
{
   public enum ErrorType
    {
        System=0,
        CodeLevel=1,
        Temporary=2,
        BadRequest=3,
        BadParameters=4
    }
}
