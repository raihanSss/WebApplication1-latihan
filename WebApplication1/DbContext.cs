using Microsoft.EntityFrameworkCore;
using WebApplication1.models;

namespace WebApplication1
{
    public class EFCoreDbContext : DbContext


    {
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
        {

        }

        public DbSet<Kendaraan> Vehicles { get; set; }

    }
}
