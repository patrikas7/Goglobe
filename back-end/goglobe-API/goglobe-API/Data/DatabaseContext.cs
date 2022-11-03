using goglobe_API.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace goglobe_API.Data
{
    public class DatabaseContext: IdentityDbContext<User>
    {
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ExludedProperty> ExludedProperties { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<IncludedProperty> IncludedProperties { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TravelOffer> TravelOffers { get; set; }
        public DbSet<TravelPhoto> TravelPhotos { get; set; }
        public DbSet<TravelProperty> TravelProperties { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=goglobeLive");
        }
    }
}
