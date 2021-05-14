using DiscountTracker.Entities.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.Entities.Dto
{
    public class GetAnnouncementsResponse:IResponse
    {
        public List<DtAnnouncement> Announcements { get; set; }
    }
}
