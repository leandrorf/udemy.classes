using Domain.DomainValueObjects;

namespace Domain.DomainEntities
{
    public class RoomEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public Price Price { get; set; }

        public bool IsAvailable
        {
            get
            {
                if ( this.InMaintenance || this.HasGuest )
                {
                    return true;
                }

                return false;
            }
        }

        public bool HasGuest
        {
            get { return true; }
        }
    }
}
