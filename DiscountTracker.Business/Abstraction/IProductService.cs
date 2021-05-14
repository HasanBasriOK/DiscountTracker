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
        DataResult<List<DtProduct>> GetActiveProducts(Expression<Func<DtProduct, bool>> filter = null);
        DataResult<List<DtProduct>> GetProductListByFollowingUser(string userId);
        Result AddHistory(string productId,double price);
    }
}
