using Domain.DomainEntities;
using Domain.DomainEnums;
using Action = Domain.DomainEnums.Action;

namespace DomainTests.Bookings
{
    public class Tests
    {
        [SetUp]
        public void Setup( )
        {
        }

        [Test]
        public void ShouldAlwaysStartWithCreatedStatus( )
        {
            var booking = new BookingEntity( );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Created ) );
        }

        [Test]
        public void ShouldSetStatusToPaidWhenPayingForABookingWithCreatedStatus( )
        {
            var booking = new BookingEntity( );

            booking.ChangeState( Action.Pay );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Paid ) );
        }

        [Test]
        public void ShouldSetStatusToCancelWhenCancelingABookingWithCreatedStatus( )
        {
            var booking = new BookingEntity( );

            booking.ChangeState( Action.Cancel );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Canceled ) );
        }

        [Test]
        public void ShouldSetStatusToFinishedWhenFinishingAPaidBooking( )
        {
            var booking = new BookingEntity( );

            booking.ChangeState( Action.Pay );
            booking.ChangeState( Action.Finish );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Finished ) );
        }

        [Test]
        public void ShouldSetStatusToRefoundedWhenRefoundingAPaidBooking( )
        {
            var booking = new BookingEntity( );

            booking.ChangeState( Action.Pay );
            booking.ChangeState( Action.Refound );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Refounded ) );
        }

        [Test]
        public void ShouldSetStatusToCreatedWhenReopeningACanceledBooking( )
        {
            var booking = new BookingEntity( );

            booking.ChangeState( Action.Cancel );
            booking.ChangeState( Action.Reopen );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Created ) );
        }

        [Test]
        public void ShouldNotChangeStatusWhenRefoundingABookingWithCreatedStatus( )
        {
            var booking = new BookingEntity( );

            booking.ChangeState( Action.Refound );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Created ) );
        }

        [Test]
        public void ShouldNotChangeStatusWhenRefoundingAFinishedBooking( )
        {
            var booking = new BookingEntity( );

            booking.ChangeState( Action.Pay );
            booking.ChangeState( Action.Finish );
            booking.ChangeState( Action.Refound );

            Assert.That( booking.CurrentStatus, Is.EqualTo( Status.Finished ) );
        }
    }
}