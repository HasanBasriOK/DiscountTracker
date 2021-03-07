using DiscountTracker.Entities.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.DataAccess.MongoDB
{
    public interface IDtAnnouncementDal:IRepository<DtAnnouncement, string>
    {
    }
}
