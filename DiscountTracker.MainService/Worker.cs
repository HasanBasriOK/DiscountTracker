using DiscountTracker.Business.Concrete;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.MainService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountTracker.MainService
{
    public class Worker : IWorker
    {
        private readonly IDtProductDal _productDal;
        private readonly IDtUserDal _userDal;
        public Worker(IDtProductDal productDal,IDtUserDal userDal)
        {
            _productDal = productDal;
            _userDal = userDal;
        }

        public void Execute()
        {
            var productService = new ProductService(_productDal, _userDal);

            var products = productService.GetActiveProducts().Data;
            double price = 0;

            foreach (var product in products)
            {
                switch (product.WebSite.ToLower())
                {
                    case "vatan":
                        var vatanManager = new VatanManager();
                        price = vatanManager.GetPrice(product.Url);
                        Console.WriteLine($"Ürün Sitesi:{product.WebSite}\nÜrün linki :{product.Url}\nÜrün Fiyatı:{price}");
                        break;
                    case "teknosa":
                        var teknosaManager = new TeknosaManager();
                        price = teknosaManager.GetPrice(product.Url);
                        Console.WriteLine($"Ürün Sitesi:{product.WebSite}\nÜrün linki :{product.Url}\nÜrün Fiyatı:{price}");
                        break;
                    default:
                        break;
                }

                productService.AddHistory(product.Id, price);
            }
        }
    }
}
