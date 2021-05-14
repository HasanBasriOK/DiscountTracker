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

            //var mediaMarktManager = new MediaMarktManager();
            var manager = new HepsiburadaManager();
            var pricea= manager.GetPrice("https://www.hepsiburada.com/casper-nirvana-c350-4000-4c00e-intel-celeron-n4000-4gb-120gb-ssd-windows-10-home-14-tasinabilir-bilgisayar-p-hbv00000qhker");

            Console.WriteLine(pricea);
            Console.Read();


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

                productService.AddHistory(product.Id, price);
            }

            
            Console.Read();
        }
    }
}
