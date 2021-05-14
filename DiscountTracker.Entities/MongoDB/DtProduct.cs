using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtProduct:BaseEntity
    {
        public string WebSite { get; set; }
        public double FirstPrice { get; set; }
        public string Url { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public List<string> FollowerList { get; set; }
        public List<DtProductPriceHistory> PriceHistory { get; set; }

        public DtProduct()
        {
            this.FollowerList = new List<string>();
            this.PriceHistory = new List<DtProductPriceHistory>();
        }
    }
}
