using System;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.DataAccess.MongoDB.Repositories
{
    public class DtProductMongoDbDal:MongoDbRepositoryBase<DtProduct>, IDtProductDal
    {
        public DtProductMongoDbDal(MongoDbSettings options) : base(options)
        {
        }
    }
}
