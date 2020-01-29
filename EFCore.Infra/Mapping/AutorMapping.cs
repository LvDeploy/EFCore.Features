using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Infra.Mapping
{
    class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("TB_Autor");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
