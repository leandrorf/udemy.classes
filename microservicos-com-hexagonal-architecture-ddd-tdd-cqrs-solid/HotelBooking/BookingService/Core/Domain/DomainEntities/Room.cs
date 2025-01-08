using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainEntities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }

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
