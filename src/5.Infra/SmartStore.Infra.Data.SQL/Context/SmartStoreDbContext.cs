using Microsoft.EntityFrameworkCore;
using SmartStore.Domain.Model.Models;
using SmartStore.Infra.Data.SQL.Mapping;
using System;
using System.Linq;

namespace SmartStore.Infra.Data.SQL.Context
{
    public class SmartStoreDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias { get; set; }

        public SmartStoreDbContext(DbContextOptions<SmartStoreDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySql("server=mysql;port=3306;userid=root;password='';database=SmartStoreDB;");
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

            //modelBuilder.Entity<Produto>()
            //    .HasData(
            //        new Produto { Id = Guid.NewGuid(), Tag = "1971C36E", Marca = "Samsung", Modelo = "Smartphone A10s", Descricao = "Memória RAM: 2GB", Valor = 949.00m },
            //        new Produto { Id = Guid.NewGuid(), Tag = "E12B6320", Marca = "LG", Modelo = "Smartphone K50s", Descricao = "Memória RAM: 3GB", Valor = 989.00m },
            //        new Categoria { Id = Guid.NewGuid(), Nome = "Telefonia"  },
            //        new Pedido { Id = Guid.NewGuid(), Instante = DateTime.Now }
            //    );

            base.OnModelCreating(modelBuilder);
        }
    }
}
