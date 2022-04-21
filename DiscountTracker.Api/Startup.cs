using DiscountTracker.Business.Abstraction;
using DiscountTracker.Business.Concrete;
using DiscountTracker.Common.QueueManagement.RabbitMq;
using DiscountTracker.DataAccess.MongoDB;
using DiscountTracker.DataAccess.MongoDB.Abstraction;
using DiscountTracker.DataAccess.MongoDB.Repositories;
using DiscountTracker.Utilities.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

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

            #region Options
            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoDbSettings"));
            services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMqConfiguration"));
            #endregion

            #region Common
            services.AddSingleton<ILogger, FileLogger>();
            services.AddSingleton<IRabbitMqManager, RabbitMqManager>();
            #endregion

            services.AddControllers();
            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title ="Discount Tracker Api",
                    Description = "An Api for db communication on discount tracker app"
                });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
                    options.RoutePrefix = "swagger";
                });
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
