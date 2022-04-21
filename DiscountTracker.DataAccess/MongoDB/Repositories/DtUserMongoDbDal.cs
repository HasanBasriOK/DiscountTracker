using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.Entities.MongoDB;
using Microsoft.Extensions.Options;

namespace DiscountTracker.DataAccess.MongoDB.Repositories
{
    public class DtUserMongoDbDal : MongoDbRepositoryBase<DtUser>, IDtUserDal
    {
        public DtUserMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
