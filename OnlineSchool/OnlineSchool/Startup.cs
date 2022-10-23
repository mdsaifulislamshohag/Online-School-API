using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using OnlineSchool.Models;
using OnlineSchool.Models.DocumentationHeader;

namespace OnlineSchool
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

            services.AddControllersWithViews();
            services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Student";

            })
            .AddCookie("Student", options =>
            {

                options.Cookie.Name = "Student.Says";
                options.LoginPath = "/Student/Login";

            })
            .AddCookie("Provider", options =>
            {
                options.Cookie.Name = "Provider.Says";
                ///// options.Cookie.Name = "Employee.Says";
                options.LoginPath = "/Provider/Login";

            })
             .AddCookie("Admin", options =>
              {
                  options.Cookie.Name = "Admin.Says";
                  ///// options.Cookie.Name = "Employee.Says";
                  options.LoginPath = "/Admin/Login";

              })

             .AddCookie("Teacher", options =>
              {
                  options.Cookie.Name = "Teacher.Says";
                  ///// options.Cookie.Name = "Employee.Says";
                  options.LoginPath = "/Teacher/Login";

              });


            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.Cookie.Name = ".AdventureWorks.Session";
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.IsEssential = true;
            });
           
            services.AddSwaggerGen(c =>
           {

               c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                   Title = "OnlineSchool", 
                   Version = "v1" ,
                   Contact = new OpenApiContact
                   {
                       Name = "Washiq Anwar Shamsi",
                       Email = "washiq35-1366@diu.edu.bd",
                     
                   },
                   License = new OpenApiLicense
                   {
                       Name = "By Shamsi",
                     
                   }

           });

               c.OperationFilter<HeaderFilter>();

               var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
               var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
               c.IncludeXmlComments(xmlPath);

           });

           

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

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.UseSwagger();

         
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Online School API V1");

               
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
