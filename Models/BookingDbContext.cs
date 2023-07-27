using Microsoft.EntityFrameworkCore;

namespace bookingdotcom.Models
{
    public class BookingDbContext :DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options):base(options){}
        public DbSet<User> Users{set;get;}
        public DbSet<Location> Locations{set;get;}
        public DbSet<Discount> Discounts{set;get;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Discount>(entity=>{
                entity.HasIndex(dis=>dis.LocationId).IsUnique();
            });
            modelBuilder.Entity<User>(entity=>{
                entity.HasIndex(u=>u.Email).IsUnique();
            });
        }
    }
}