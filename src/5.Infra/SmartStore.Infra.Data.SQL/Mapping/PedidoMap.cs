using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStore.Domain.Model.Models;
using System;

namespace SmartStore.Infra.Data.SQL.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Instante)
                .HasColumnType("DateTime(0)")
                .IsRequired();            

            builder.Property(c => c.Total)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}
