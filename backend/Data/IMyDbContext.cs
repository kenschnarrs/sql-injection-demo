using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public interface IMyDbContext
    {
        DbSet<MyEntity> MyEntities { get; set; }
    }
}