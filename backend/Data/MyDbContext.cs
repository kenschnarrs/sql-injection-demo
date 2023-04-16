using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using backend.Models;
using MySql.EntityFrameworkCore;

namespace backend.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(5, 7, 21));

            optionsBuilder.UseMySql("server=localhost;user=root;database=sys;port=3306;password=my_password2", serverVersion)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

        public DbSet<MyEntity> MyEntities { get; set; }
    }
}