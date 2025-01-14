using Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainPorts
{
    public interface IGuestRepository
    {
        Task<GuestEntity> Get( );
        Task<int> Create( GuestEntity guest );
    }
}
