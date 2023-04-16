using Microsoft.EntityFrameworkCore;
//using MySql.EntityFrameworkCore.Extensions;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using backend.Models;
//using MySql.EntityFrameworkCore;

namespace backend.Data
{
    public class MyDbContext : DbContext, IMyDbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the entity mappings here
            modelBuilder.Entity<MyEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.un).HasMaxLength(50);
            });
        }
    }
}