using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DiscountTracker.Entities.Core;
using DiscountTracker.Entities.Dto;
using DiscountTracker.Entities.MongoDB;

namespace DiscountTracker.Business.Abstraction
{
    public interface IProductService
    {
        Result TrackProduct(TrackProductRequest request);
        IDataResult<List<DtProduct>> GetActiveProducts(Expression<Func<DtProduct, bool>> filter = null);
    }
}
