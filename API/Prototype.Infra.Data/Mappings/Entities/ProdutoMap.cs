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
    public class ProdutoMap : GenericMap<Produto>, IEntityTypeConfiguration<Produto>, IEntityMapping
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            DefaultMap(builder: builder, tableName: "Produtos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Valor).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.Tem_Promocao).HasDefaultValue(false);

            builder.HasOne(x => x.Promocao).WithOne().HasForeignKey<Produto>(x => x.Id_Promocao);
        }
    }
}
