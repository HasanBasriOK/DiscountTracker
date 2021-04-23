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
        public DtUser CreatedUser { get; set; }
        public List<DtUser> FollowerList { get; set; }

        public DtProduct()
        {
            this.FollowerList = new List<DtUser>();
        }
    }
}
