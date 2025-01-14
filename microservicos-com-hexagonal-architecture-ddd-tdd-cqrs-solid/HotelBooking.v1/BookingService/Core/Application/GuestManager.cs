using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.DomainExceptions;
using Domain.DomainPorts;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private readonly IGuestRepository _GuestRepository;

        public GuestManager( IGuestRepository guestRepository )
        {
            _GuestRepository = guestRepository;
        }

        public async Task<GuestResponse> CreateGuest( CreateGuestRequest request )
        {
            try
            {
                var guest = GuestDTO.MapToEntity( request.Data );

                await guest.Save( _GuestRepository );

                request.Data.Id = guest.Id;

                return new GuestResponse
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch ( InvalidPersonDocumentIdException )
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.INVALID_PERSON_ID,
                    Message = "The ID passed is not valid"
                };
            }
            catch ( MissingRequiredInformation )
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.MISSING_REQUIRED_INFORMATION,
                    Message = "Missing required information passed"
                };
            }
            catch ( InvalidEmailException )
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.INVALID_EMAIL,
                    Message = "The given email is not valid"
                };
            }
            catch ( Exception )
            {
                return new GuestResponse
                {
                    Success = false,
                    ErrorCodes = ErrorCodes.COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }

        }
    }
}
