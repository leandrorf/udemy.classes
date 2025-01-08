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
        Task<Guest> Get( );
        Task<int> Save( Guest guest );
    }
}
