using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Framework.ThirdAPIs;
using WebMotors.Framework.Repositories;
using WebMotors.Framework.Models;
using System.Net.Http;
using WebMotors.Framework.Services;

namespace WebMotors.Framework.Extensions
{
    public static class ServicesConfigurarionExtend
    {
        public static IServiceCollection AddWebMotorsFrameworksServices(this IServiceCollection services, AppConfigurations configurations)
        {
            
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(configurations.WebMotorsAPIUrl),
                //Timeout = new TimeSpan(configurations.Timeout)

            };

            services.AddSingleton(httpClient);
            services.AddScoped<IWebMotorsAPI, WebMotorsAPI>();
            services.AddScoped<IAnnounceRepository, AnnounceRepository>();
            services.AddScoped<IAnnounceService, AnnounceService>();

            return services;
        }
    }
    
}
