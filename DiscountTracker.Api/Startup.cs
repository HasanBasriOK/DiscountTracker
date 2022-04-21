using DiscountTracker.Business.Abstraction;
using DiscountTracker.Business.Concrete;
using DiscountTracker.DataAccess.MongoDB;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.DataAccess.MongoDB.Repositories;
using DiscountTracker.Utilities.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountTracker.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<DataAccess.MongoDB.MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.AddSingleton<Utilities.Logger.ILogger, FileLogger>();


            #region Data Access
            services.AddSingleton(typeof(MongoDbSettings));
            services.AddSingleton<IDtAnnouncementDal, DtAnnouncementMongoDbDal>();
            services.AddSingleton<IDtUserDal, DtUserMongoDbDal>();
            services.AddSingleton<IDtProductDal, DtProductMongoDbDal>();

            #endregion

            #region Business 
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IProductService, ProductService>();
            #endregion

           

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    
    }
}
