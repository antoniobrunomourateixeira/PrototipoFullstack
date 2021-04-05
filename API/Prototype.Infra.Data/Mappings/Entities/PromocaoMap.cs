using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prototype.Domain.Entities;
using Prototype.Infra.Data.Interfaces;
using Prototype.Infra.Data.Mappings.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Infra.Data.Mappings.Entities
{
    public class PromocaoMap : GenericMap<Promocao>, IEntityTypeConfiguration<Promocao>, IEntityMapping
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            DefaultMap(builder: builder, tableName: "Promocoes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Leve).IsRequired();
            builder.Property(x => x.Pague);
            builder.Property(x => x.Valor).HasDefaultValue(0).HasColumnType("decimal(18,2)"); ;
        }
    }
}
