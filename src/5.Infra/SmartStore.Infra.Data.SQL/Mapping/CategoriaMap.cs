using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStore.Domain.Model.Models;
using System;

namespace SmartStore.Infra.Data.SQL.Mapping
{
    class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");            
        }
    }
}
