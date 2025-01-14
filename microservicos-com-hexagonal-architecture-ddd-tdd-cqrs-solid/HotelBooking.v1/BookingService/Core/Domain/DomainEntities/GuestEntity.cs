using Domain.DomainExceptions;
using Domain.DomainPorts;
using Domain.DomainShared;
using Domain.DomainValueObjects;

namespace Domain.DomainEntities
{
    public class GuestEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public PersonId DocumentId { get; set; }

        public async Task Save( IGuestRepository guestRepository )
        {
            this.ValidateState( );

            if ( this.Id == 0 )
            {
                this.Id = await guestRepository.Create( this );
            }
            else
            {
                //await guestRepository.Update(this);
            }
        }

        private void ValidateState( )
        {
            if ( DocumentId == null
                || DocumentId.IdNumber.Length <= 3
                || DocumentId.DocumentType == 0 )
            {
                throw new InvalidPersonDocumentIdException( );
            }

            if ( Name == null || Surname == null || Email == null )
            {
                throw new MissingRequiredInformation( );
            }

            if ( Utils.ValidateEmail( Email ) == false )
            {
                throw new InvalidEmailException( );
            }
        }
    }
}
