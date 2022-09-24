using goglobe_API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace goglobe_API.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Agency> Agencies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=goglobe");
        }
    }
}
