using System;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.DataAccess.MongoDB.Abstraction
{
    public interface IDtProductDal: IRepository<DtProduct, string>
    {
        
    }
}
