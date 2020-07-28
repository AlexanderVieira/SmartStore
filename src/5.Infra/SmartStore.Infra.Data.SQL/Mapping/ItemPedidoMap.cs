using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartStore.Domain.Model.Models;

namespace SmartStore.Infra.Data.SQL.Mapping
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Quantidade)
                .HasColumnType("int(10)")                
                .IsRequired();

            builder.Property(c => c.Desconto)
                .HasColumnType("double(10,2)")                
                .IsRequired();

            builder.Property(c => c.Valor)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.HasKey(ip => new { ip.ProdutoId, ip.PedidoId });

            builder.HasOne<Produto>(ip => ip.Produto)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(ip => ip.ProdutoId);

            builder.HasOne<Pedido>(ip => ip.Pedido)
                .WithMany(pe => pe.Itens)
                .HasForeignKey(ip => ip.PedidoId);
        }
    }
}
