using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.Dto
{
    public class ApiRequest<T> where T : class,IRequest
    {
    }
}
