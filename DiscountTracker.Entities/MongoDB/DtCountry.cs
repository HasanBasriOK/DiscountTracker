using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtCountry : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<DtCity> Cities { get; set; }
    }
}
