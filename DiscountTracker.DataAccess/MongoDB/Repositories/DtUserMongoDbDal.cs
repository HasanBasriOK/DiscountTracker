using System;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.DataAccess.MongoDB.Repositories
{
    public class DtUserMongoDbDal : MongoDbRepositoryBase<DtUser>, IDtUserDal
    {
        public DtUserMongoDbDal(MongoDbSettings options) : base(options)
        {
        }
    }
}
