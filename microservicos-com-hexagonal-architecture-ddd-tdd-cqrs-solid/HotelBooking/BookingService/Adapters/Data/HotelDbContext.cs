using Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HotelDbContext : DbContext
    {
        public virtual DbSet<Guest> Guests { get; set; }

        public HotelDbContext( DbContextOptions<HotelDbContext> options ) : base( options )
        {
        }
    }
}
