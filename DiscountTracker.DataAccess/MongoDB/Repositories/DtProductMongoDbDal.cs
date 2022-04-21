using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.Entities.MongoDB;
using Microsoft.Extensions.Options;

namespace DiscountTracker.DataAccess.MongoDB.Repositories
{
    public class DtProductMongoDbDal:MongoDbRepositoryBase<DtProduct>, IDtProductDal
    {
        public DtProductMongoDbDal(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
