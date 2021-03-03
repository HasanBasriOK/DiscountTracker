using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtProductPriceHistory:BaseEntity
    {
        public DtProduct Product { get; set; }
        public DateTime CheckDate { get; set; }
        public double Price { get; set; }
        public bool IsChanged { get; set; }
    }
}
