using Domain.DomainEntities;
using Domain.DomainPorts;

namespace Data.Guest
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _HotelDbContext;

        public GuestRepository( HotelDbContext hotelDbContext )
        {
            _HotelDbContext = hotelDbContext;
        }

        public async Task<int> Create( GuestEntity guest )
        {
            _HotelDbContext.Guests.Add( guest );
            await _HotelDbContext.SaveChangesAsync( );
            return guest.Id;
        }

        public Task<GuestEntity> Get( )
        {
            throw new NotImplementedException( );
        }
    }
}
