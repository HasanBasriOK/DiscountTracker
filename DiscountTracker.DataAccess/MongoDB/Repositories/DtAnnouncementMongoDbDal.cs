using DiscountTracker.Entities.MongoDB;
using Microsoft.Extensions.Options;

namespace DiscountTracker.DataAccess.MongoDB
{
    public class DtAnnouncementMongoDbDal : MongoDbRepositoryBase<DtAnnouncement>, IDtAnnouncementDal
    {
        public DtAnnouncementMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
