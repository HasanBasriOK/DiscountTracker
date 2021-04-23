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

namespace DiscountTracker.Business.Concrete
{
    public class ProductService:IProductService
    {
        private readonly IDtProductDal _productDal;
        private readonly IDtUserDal _userDal;
        public ProductService(IDtProductDal productDal,IDtUserDal userDal)
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
                if (!product.FollowerList.Any(x=> x.Id==request.UserId))
                {
                    var user = _userDal.Get(x => x.Id == request.UserId).FirstOrDefault();
                    product.FollowerList.Add(user);
                    _productDal.UpdateAsync(product.Id,product);

                    return new SuccessResult("Successfull");
                }
                else
                {
                    return new ErrorResult(Constants.UserAlreadyTrackingThisProduct);
                }
            }
            //ürün hiç eklenmemiş takibe başla
            else
            {
                var user = _userDal.Get(x => x.Id == request.UserId).FirstOrDefault();

                product = new DtProduct();
                product.CreatedDate = new DateTime();
                product.CreatedUser = user;
                product.CurrentPrice = 0;
                product.FirstPrice = 0;
                product.FollowerList.Add(user);
                product.IsTransferred = false;
                product.Url = request.Url;
                product.WebSite = request.WebSite;

                _productDal.AddAsync(product);

                return new SuccessResult("Successfull");
            }

        }

        public IDataResult<List<DtProduct>> GetActiveProducts(Expression<Func<DtProduct, bool>> filter=null)
        {
            var result = _productDal.Get(filter).ToList();

            return new SuccessDataResult<List<DtProduct>>(result, "Successfull");
        }
    }
}
