using System;
using DiscountTracker.Business.Concrete;
using DiscountTracker.DataAccess.MongoDB.Repositories;
using DiscountTracker.MainService.Managers;

namespace DiscountTracker.MainService
{
    class Program
    {

        System.Timers.Timer _timer = new System.Timers.Timer();


        static void Main(string[] args)
        {
            /*var vatanManager = new VatanManager();

            var price= vatanManager.GetPrice("https://www.vatanbilgisayar.com/resimli-deyimler-ve-atasozleri-sozlugu-evrelsel-iletisim-yayinlari-evrnsl344616.html");*/

            var userDal = new DtUserMongoDbDal(new DataAccess.MongoDB.MongoDbSettings());
            var productDal = new DtProductMongoDbDal(new DataAccess.MongoDB.MongoDbSettings());

            var productService = new ProductService(productDal, userDal);

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
            }

            
            Console.Read();
        }
    }
}
