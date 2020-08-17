using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMotors.Framework.Extensions;
using WebMotors.Framework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

namespace WebMotors.Challenge
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
            services.AddWebMotorsFrameworksServices();

            services.AddDbContext<WebMotorsDbContext>(options =>
                options.UseSqlServer(Configuration["WebMotorsDb:ConnectionString"]));

            //services.AddControllers()
            //        .AddNewtonsoftJson(options =>
            //              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "WebMotors API",
                        Version = "v1",
                        Description = "WebMotors API Challenger",
                        Contact = new OpenApiContact
                        {
                            Name = "Leonardo Puglia - Linkedin",
                            Url = new Uri("https://www.linkedin.com/in/leonardo-puglia-541ab2110/")
                        }
                    });
                c.EnableAnnotations();
            });

            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebMotors API V1");
            });

            app.UseReDoc(c =>
            {
                c.SpecUrl = "/swagger/v1/swagger.json";
                c.DocumentTitle = "WebMotors API v1";

            });


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
