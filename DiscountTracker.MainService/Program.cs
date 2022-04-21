using System;
using DiscountTracker.Business.Concrete;
using DiscountTracker.DataAccess.MongoDB.Repositories;
using DiscountTracker.MainService.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using DiscountTracker.DataAccess.MongoDB.Abstraction;

namespace DiscountTracker.MainService
{
    class Program
    {

        System.Timers.Timer _timer = new System.Timers.Timer();


        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);

            IConfiguration Configuration = builder.Build();

            //For Dependency injection
            using IHost host = Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
       services.Configure<DataAccess.MongoDB.MongoDbSettings>(Configuration.GetSection("MongoDbSettings"))
       .AddSingleton<IWorker,Worker>()
       .AddSingleton<IDtProductDal,DtProductMongoDbDal>()
       .AddSingleton<IDtUserDal,DtUserMongoDbDal>()).
       Build();


            var worker = host.Services.GetService<IWorker>();
            worker.Execute();

            //var mediaMarktManager = new MediaMarktManager();
            //var manager = new HepsiburadaManager();
            //var pricea = manager.GetPrice("https://www.hepsiburada.com/casper-nirvana-c350-4000-4c00e-intel-celeron-n4000-4gb-120gb-ssd-windows-10-home-14-tasinabilir-bilgisayar-p-hbv00000qhker");

            //Console.WriteLine(pricea);
            //Console.Read();






            Console.Read();
        }
    }
}
