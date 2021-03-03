using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtCity : BaseEntity
    {
        public string Name { get; set; }
        public DtCountry Country { get; set; }
    }
}
