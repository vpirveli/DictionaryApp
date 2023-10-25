using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    internal class DefinitionConfig : IEntityTypeConfiguration<Definition>
    {
        public void Configure(EntityTypeBuilder<Definition> builder)
        {
            builder.HasIndex(x => x.Description);
        }
    }
}
