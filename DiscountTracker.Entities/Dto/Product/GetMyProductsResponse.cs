using System;
using System.Collections.Generic;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.Entities.Dto
{
    public class GetMyProductsResponse:IResponse
    {
        public List<DtProduct> Products { get; set; }
    }
}
