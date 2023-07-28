using Microsoft.EntityFrameworkCore;

namespace bookingdotcom.Models
{
    public class BookingDbContext :DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options):base(options){}
        public DbSet<User> Users{set;get;}
        public DbSet<Location> Locations{set;get;}
        public DbSet<Discount> Discounts{set;get;}
        public DbSet<Rating> Ratings{set;get;}
        public DbSet<Room> Rooms{set;get;}
        public DbSet<UnavailableDate> UnavailableDates{set;get;}
        public DbSet<RoomBed> RoomBeds{set;get;}
        public DbSet<BedType> BedTypes{set;get;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Discount>(entity=>{
                entity.HasIndex(dis=>dis.LocationId).IsUnique();
            });
            modelBuilder.Entity<User>(entity=>{
                entity.HasIndex(u=>u.Email).IsUnique();
            });
            modelBuilder.Entity<RoomBed>(entity=>{
                entity.HasIndex(rb=>rb.BedTypeId).IsUnique();
            });
        }
    }
}