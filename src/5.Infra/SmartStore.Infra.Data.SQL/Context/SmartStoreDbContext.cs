using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Model.Models;
using SmartStore.Infra.Data.SQL.Mapping;
using System.Linq;

namespace SmartStore.Infra.Data.SQL.Context
{
    public class SmartStoreDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }

        public SmartStoreDbContext(DbContextOptions<SmartStoreDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=.\\Data;Database=SmartStoreDB;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                    .SelectMany(t => t.GetProperties())
                    .Where(p => p.ClrType == typeof(string)))
            {
                property.Relational().ColumnType = "varchar(100)";
            }

            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItemPedidoMap());
            modelBuilder.ApplyConfiguration(new ProdutoCategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
