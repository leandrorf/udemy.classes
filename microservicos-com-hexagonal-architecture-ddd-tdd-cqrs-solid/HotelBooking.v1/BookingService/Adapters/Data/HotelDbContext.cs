using Data.Guest;
using Data.Room;
using Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HotelDbContext : DbContext
    {
        public virtual DbSet<GuestEntity> Guests { get; set; }
        public virtual DbSet<RoomEntity> Rooms { get; set; }
        public virtual DbSet<BookingEntity> Bookings { get; set; }

        public HotelDbContext( DbContextOptions<HotelDbContext> options ) : base( options )
        {
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.ApplyConfiguration( new GuestConfiguration( ) );
            modelBuilder.ApplyConfiguration( new RoomConfiguration( ) );
        }
    }
}
