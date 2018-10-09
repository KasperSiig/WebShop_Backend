﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebShop.Core.ApplicationService;
using WebShop.Infrastructure.Data;

namespace WebShopWebAPI
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfiguration _conf { get; }

        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (_env.IsDevelopment())
            {
                services.AddDbContext<WebShopContext>(
                    opt => opt.UseSqlite("Data Source=webShop.db"));
            }
            else
            {
                services.AddDbContext<WebShopContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("defaultConnection")));
            }
            
//            services.AddScoped<IUserService, UserService>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<WebShopContext>();
                    ctx.Database.EnsureCreated();
                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseMvc();
        }
    }
}
