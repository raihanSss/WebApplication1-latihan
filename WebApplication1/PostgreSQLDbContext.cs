using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1
{
    public class PostgreSQLDbContext : DbContext
    {
        
        public PostgreSQLDbContext(DbContextOptions<PostgreSQLDbContext> options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }

    }
}

