using Application;
using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route( "api/[controller]" )]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _Logger;
        private readonly IGuestManager _GuestManager;

        public GuestController( ILogger<GuestController> logger, IGuestManager guestManager )
        {
            _Logger = logger;
            _GuestManager = guestManager;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post( GuestDTO guest )
        {
            var request = new CreateGuestRequest
            {
                Data = guest
            };

            var res = await _GuestManager.CreateGuest( request );

            if ( res.Success )
            {
                return Created( "", res.Data );
            }

            if ( res.ErrorCodes == ErrorCodes.NOT_FOUND )
            {
                return BadRequest( res );
            }
            else if( res.ErrorCodes == ErrorCodes.INVALID_PERSON_ID )
            {
                return BadRequest( res );
            }
            else if ( res.ErrorCodes == ErrorCodes.MISSING_REQUIRED_INFORMATION )
            {
                return BadRequest( res );
            }
            else if ( res.ErrorCodes == ErrorCodes.INVALID_EMAIL )
            {
                return BadRequest( res );
            }
            else if ( res.ErrorCodes == ErrorCodes.COULD_NOT_STORE_DATA )
            {
                return BadRequest( res );
            }

            _Logger.LogError( "Response with unknown ErrorCode Returned", res );
            return BadRequest( 500 );
        }
    }
}
