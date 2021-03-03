using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtWebSite:BaseEntity
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
