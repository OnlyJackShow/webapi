using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebSwagger.Common;
using WebSwagger.DAL;

namespace WebSwagger
{
    public class Startup
    {
        /// <summary>
        /// SyncDb
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //加载swagger
            services.AddSwaggerGen(options=> 
            {
                options.SwaggerDoc("V1", new Info
                {
                    Version="V1",                    
                    Title="API",
                    Description = "API文档",
                    TermsOfService="None"
                });

                var basePath = AppContext.BaseDirectory;                
                var xmlPathByModel = Path.Combine(basePath, "Test.Model.xml");               
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                options.IncludeXmlComments(xmlPath, true);
            });
            services.AddScoped<BaseServices>();
            services.AddScoped<CashServices>();
            //连接数据库
            services.AddDbContext<CoreDbContext>(options => options.UseMySql(Configuration.GetConnectionString("RetailkingDb")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// SyncDb
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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

            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(action=> 
            {
                action.ShowExtensions();
                action.SwaggerEndpoint("/swagger/V1/swagger.json", "V1 Docs");
                action.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
