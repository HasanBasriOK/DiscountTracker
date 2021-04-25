using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtProductPriceHistory:BaseEntity
    {
        public DateTime CheckDate { get; set; }
        public double Price { get; set; }
    }
}
