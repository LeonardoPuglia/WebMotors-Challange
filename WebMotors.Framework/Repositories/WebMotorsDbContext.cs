using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebMotors.Framework.Entities;
using WebMotors.Framework.Maps;

namespace WebMotors.Framework.Repositories
{
    public class WebMotorsDbContext : DbContext
    {
        public WebMotorsDbContext(DbContextOptions<WebMotorsDbContext> options) : base(options)
        {

        }

        public DbSet<Announce> Announces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Announce>().HasKey(x => x.Id);
            modelBuilder.Entity<Announce>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Announce>().Property(x => x.CreateDate).IsRequired().HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Announce>().Property(x => x.UpdateDate);
            modelBuilder.Entity<Announce>().Property(x => x.UniqueId).IsRequired().HasDefaultValueSql("NEWID()");

        }
    }
}
