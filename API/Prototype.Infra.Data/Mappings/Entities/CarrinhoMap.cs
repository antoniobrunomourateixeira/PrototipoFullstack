using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prototype.Domain.Entities;
using Prototype.Infra.Data.Interfaces;
using Prototype.Infra.Data.Mappings.Generics;

namespace Prototype.Infra.Data.Mappings.Entities
{
    public class CarrinhoMap : GenericMap<Carrinho>, IEntityTypeConfiguration<Carrinho>, IEntityMapping
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            DefaultMap(builder: builder, tableName: "Carrinho");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Valor).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Produto).WithOne().HasForeignKey<Carrinho>(x => x.Id_Produto);
        }
    }
}
