using System;
using DiscountTracker.Business.Abstraction;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.Entities.Core;
using DiscountTracker.Entities.Dto;
using System.Linq;
using DiscountTracker.Utilities;
using DiscountTracker.Entities.MongoDB;
using System.Collections.Generic;
using System.Linq.Expressions;
using DiscountTracker.Common.Constants;

namespace DiscountTracker.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IDtProductDal _productDal;
        private readonly IDtUserDal _userDal;
        public ProductService(IDtProductDal productDal, IDtUserDal userDal)
        {
            _productDal = productDal;
            _userDal = userDal;
        }

        public Result TrackProduct(TrackProductRequest request)
        {
            var product = _productDal.Get(x => x.Url == request.Url).FirstOrDefault();
            //ürün zaten var,takipçi listesini kontrol et isteği gönderen kullanıcı takipçi listesinde var mı
            if (product != null)
            {
                //isteği gönderen kullanıcı takipçi listesinde var mı
                if (!product.FollowerList.Contains(request.UserId))
                {
                    product.FollowerList.Add(request.UserId);
                    _productDal.UpdateAsync(product.Id, product);

                    return new SuccessResult("Successfull");
                }
                else
                    return new ErrorResult(MessageConstants.UserAlreadyTrackingThisProduct);
            }
            //ürün hiç eklenmemiş takibe başla
            else
            {

                product = new DtProduct();
                product.CreatedDate = new DateTime();
                product.CreatedUser = request.UserId;
                product.CurrentPrice = 0;
                product.FirstPrice = 0;
                product.FollowerList.Add(request.UserId);
                product.IsTransferred = false;
                product.Url = request.Url;
                product.WebSite = request.WebSite;

                _productDal.AddAsync(product);

                return new SuccessResult("Successfull");
            }

        }

        public DataResult<List<DtProduct>> GetActiveProducts(Expression<Func<DtProduct, bool>> filter = null)
        {
            var result = _productDal.Get(filter).ToList();

            return new SuccessDataResult<List<DtProduct>>(result, "Successfull");
        }

        public DataResult<List<DtProduct>> GetProductListByFollowingUser(string userId)
        {
            var user = _userDal.Get(x => x.Id == userId).FirstOrDefault();
            var result = _productDal.Get(x => x.FollowerList.Contains(userId)).ToList();

            return new SuccessDataResult<List<DtProduct>>(result, "Successfull");
        }

        public Result AddHistory(string productId, double price)
        {
            var product = _productDal.Get(x => x.Id == productId).FirstOrDefault();

            var historyItem = new DtProductPriceHistory();
            historyItem.CheckDate = DateTime.Now;
            historyItem.Price = price;
            product.PriceHistory.Add(historyItem);
            _productDal.UpdateAsync(product, x => x.Id == productId);

            return new SuccessResult("Successfull");
        }
    }
}
