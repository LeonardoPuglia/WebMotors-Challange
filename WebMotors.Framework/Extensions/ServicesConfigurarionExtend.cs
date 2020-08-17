using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Framework.ThirdAPIs;
using WebMotors.Framework.Repositories;

namespace WebMotors.Framework.Extensions
{
    public static class ServicesConfigurarionExtend
    {
        public static IServiceCollection AddWebMotorsFrameworksServices(this IServiceCollection services)
        {

            services.AddTransient<IWebMotorsAPI, WebMotorsAPI>();
            services.AddScoped<IAnnounceRepository, AnnounceRepository>();
            return services;
        }
    }
    
}
