using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStore.Domain.Model.Models;

namespace SmartStore.Infra.Data.SQL.Mapping
{
    public class ProdutoCategoriaMap : IEntityTypeConfiguration<ProdutoCategoria>
    {
        public void Configure(EntityTypeBuilder<ProdutoCategoria> builder)
        {
            builder.HasKey(ip => new { ip.ProdutoId, ip.CategoriaId });

            builder.HasOne<Produto>(ip => ip.Produto)
                .WithMany(p => p.Categorias)
                .HasForeignKey(ip => ip.ProdutoId);

            builder.HasOne<Categoria>(ip => ip.Categoria)
                .WithMany(pe => pe.Produtos)
                .HasForeignKey(ip => ip.CategoriaId);
        }
    }
}
