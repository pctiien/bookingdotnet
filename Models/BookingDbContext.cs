using Microsoft.EntityFrameworkCore;

namespace bookingdotcom.Models
{
    public class BookingDbContext :DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options):base(options){
        }
        public DbSet<User> Users{set;get;}
        public DbSet<Location> Locations{set;get;}
        public DbSet<Discount> Discounts{set;get;}
        public DbSet<Rating> Ratings{set;get;}
        public DbSet<Room> Rooms{set;get;}
        public DbSet<UnavailableDate> UnavailableDates{set;get;}
        public DbSet<BedType> BedTypes{set;get;}
        public DbSet<LocationImage> LocationImages{set;get;}
        public DbSet<RoomImg> RoomImages{set;get;}
        public DbSet<Facility> RoomFacilities{set;get;}
        public DbSet<RoomFacilityLink> RoomFacilityLinks{set;get;}
        public DbSet<RoomBedTypeLink> RoomBedTypeLinks{set;get;}
        public DbSet<RoomType> RoomTypes{set;get;}
        public DbSet<RoomTypeName> RoomTypeNames{set;get;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); // Enable lazy loading proxies
        }   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Discount>(entity=>{
                entity.HasIndex(dis=>dis.LocationId).IsUnique();
            });
            modelBuilder.Entity<User>(entity=>{
                entity.HasIndex(u=>u.Email).IsUnique();
            });
            modelBuilder.Entity<RoomFacilityLink>(entity=>{
                entity.HasKey(e=>new{e.RoomId,e.FacilityId});
            });
            modelBuilder.Entity<RoomBedTypeLink>(entity=>{
                entity.HasKey(e=>new{e.BedTypeId,e.RoomId});
            });
            modelBuilder.Entity<RoomType>(entity=>{
                entity.HasIndex(e=>e.RoomTypeNameId).IsUnique();
            });
        }
    }
}