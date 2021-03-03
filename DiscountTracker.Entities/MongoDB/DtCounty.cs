using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtCounty : BaseEntity
    {
        public string Name { get; set; }
        public DtCity City { get; set; }
    }
}
