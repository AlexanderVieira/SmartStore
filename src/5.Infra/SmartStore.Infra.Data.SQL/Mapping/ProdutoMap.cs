using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStore.Domain.Model.Models;
using System;

namespace SmartStore.Infra.Data.SQL.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");            

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
