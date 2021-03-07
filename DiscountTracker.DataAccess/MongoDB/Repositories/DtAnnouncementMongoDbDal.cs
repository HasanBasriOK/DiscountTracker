using DiscountTracker.Entities.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountTracker.DataAccess.MongoDB
{
    public class DtAnnouncementMongoDbDal : MongoDbRepositoryBase<DtAnnouncement>, IDtAnnouncementDal
    {
        public DtAnnouncementMongoDbDal(MongoDbSettings options) : base(options)
        {
        }
    }
}
