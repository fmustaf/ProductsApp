using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using ProductApp.Models;
//using Swashbuckle.AspNetCore.Swagger;
//using Swagger.Net;
//using Microsoft.OpenApi.Models;
using NSwag.AspNetCore;

namespace ProductApp
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
            //services.AddDbContext<ProductAppContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("ProductAppContext")));

            services.AddDbContext<ProductContext>(options =>
                options.UseInMemoryDatabase("ProductList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Used with OLD Swashbuckle
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "Simple Items API", Version = "v1" });
            //});

            services.AddOpenApiDocument();
            //services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Products and Items API");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            // httpConfiguration
            //app.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API")).EnableSwaggerUi();

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
