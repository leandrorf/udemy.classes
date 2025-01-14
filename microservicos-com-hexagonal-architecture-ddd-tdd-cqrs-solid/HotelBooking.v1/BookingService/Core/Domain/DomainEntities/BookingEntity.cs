using Domain.DomainEnums;
using Action = Domain.DomainEnums.Action;

namespace Domain.DomainEntities
{
    public class BookingEntity
    {
        public int Id { get; set; }
        public DateTime PlaceAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public RoomEntity Room { get; set; }
        public GuestEntity Guest { get; set; }
        private Status Status { get; set; }
        public Status CurrentStatus { get { return this.Status; } }

        public void ChangeState( Action action )
        {
            this.Status = (this.Status, action) switch
            {
                (Status.Created, Action.Pay ) => Status.Paid,
                (Status.Created, Action.Cancel ) => Status.Canceled,
                (Status.Paid, Action.Finish ) => Status.Finished,
                (Status.Paid, Action.Refound ) => Status.Refounded,
                (Status.Canceled, Action.Reopen ) => Status.Created,
                _ => this.Status
            };
        }

        public BookingEntity( )
        {
            this.Status = Status.Created;
        }
    }
}
