using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.MongoDB
{
    public class DtAnnouncement : BaseEntity
    {
        public string Image { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int Order { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
