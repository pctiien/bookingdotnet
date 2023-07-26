using Microsoft.EntityFrameworkCore;

namespace bookingdotcom.Models
{
    public class BookingDbContext :DbContext
    {
        public BookingDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<User>? Users{set;get;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}