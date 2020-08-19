using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using WebMotors.Framework.Repositories;

namespace WebMotors.Framework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<WebMotorsDbContext>
    {
        public WebMotorsDbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<WebMotorsDbContext>();

            var connectionString = configuration.GetValue<String>("WebMotorsDb:ConnectionString");

            builder.UseSqlServer(connectionString);

            return new WebMotorsDbContext(builder.Options);
        }
    }
}

