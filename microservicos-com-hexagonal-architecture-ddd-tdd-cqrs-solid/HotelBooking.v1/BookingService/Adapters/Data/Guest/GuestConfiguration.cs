﻿using Domain.DomainEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Guest
{
    public class GuestConfiguration : IEntityTypeConfiguration<GuestEntity>
    {
        public void Configure( EntityTypeBuilder<GuestEntity> builder )
        {
            builder.HasKey( x => x.Id );
            builder.OwnsOne( x => x.DocumentId ).Property( x => x.IdNumber );
            builder.OwnsOne( x => x.DocumentId ).Property( x => x.DocumentType );
        }
    }
}
