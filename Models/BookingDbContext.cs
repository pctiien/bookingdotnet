using Microsoft.EntityFrameworkCore;

namespace bookingdotcom.Models
{
    public class BookingDbContext :DbContext
    {
        DbSet<User>? users ;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}