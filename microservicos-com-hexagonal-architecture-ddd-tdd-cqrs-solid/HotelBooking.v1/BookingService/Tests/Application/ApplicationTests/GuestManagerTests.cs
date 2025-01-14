using Application;
using Application.Guest.DTO;
using Application.Guest.Requests;
using Domain.DomainEntities;
using Domain.DomainPorts;
using System.Net.WebSockets;

namespace ApplicationTests
{
    class FakeRepo : IGuestRepository
    {
        public Task<int> Create( GuestEntity guest )
        {
            return Task.FromResult( 111 );
        }

        public Task<GuestEntity> Get( )
        {
            throw new NotImplementedException( );
        }
    }

    public class GuestManagerTests
    {
        GuestManager guestManager;

        [SetUp]
        public void Setup( )
        {
            var fakeRepo = new FakeRepo( );
            guestManager = new GuestManager( fakeRepo );
        }

        [Test]
        public void Test1( )
        {
            var guestDto = new GuestDTO( )
            {
                Name = "Fulano",
                Surname = "Ciclano",
                Email = "email@email.com",
                IdNumber = "abcs",
                IdTypeCode = 1
            };

            var request = new CreateGuestRequest( )
            {
                Data = guestDto
            };

            var res = guestManager.CreateGuest( request ).Result;
            Assert.That( res, Is.Not.Null );
            Assert.That( res.Success, Is.True );
        }
    }
}