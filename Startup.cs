using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using product_viewer.Services;
using product_viewer.Entities;
using Microsoft.EntityFrameworkCore;

namespace product_viewer
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc()
            .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()))
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #if DEBUG
                services.AddTransient<IMailService, LocalMailService>();
            #else
                services.AddTransient<IMailService, CloudMailService>();
            #endif

            var connectionString = @"Server=localhost\SQLEXPRESS01;Database=ProductInfoDb;Trusted_Connection=True;";
            services.AddDbContext<ProductInfoContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IProductInfoRepository, ProductInfoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ProductInfoContext productInfoContext)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            productInfoContext.EnsureSeedDataForContext();

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Entities.Product, Models.ProductNoFeaturesDto>();
                cfg.CreateMap<Entities.Product, Models.ProductDto>();
                cfg.CreateMap<Entities.ProductFeature, Models.ProductFeatureDto>();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
