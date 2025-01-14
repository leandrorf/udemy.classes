using Domain.DomainEntities;
using Domain.DomainEnums;
using Domain.DomainValueObjects;

namespace Application.Guest.DTO
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public int IdTypeCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }

        public static GuestEntity MapToEntity(GuestDTO guestDTO )
        {
            return new GuestEntity
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                Surname = guestDTO.Surname,
                Email = guestDTO.Email,
                DocumentId = new PersonId
                {
                    IdNumber  = guestDTO.IdNumber,
                    DocumentType = (DocumentType)guestDTO.IdTypeCode
                }
            };
        }
    }
}
