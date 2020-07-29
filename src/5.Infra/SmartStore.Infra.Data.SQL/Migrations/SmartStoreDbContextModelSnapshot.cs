﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartStore.Infra.Data.SQL.Context;

namespace SmartStore.Infra.Data.SQL.Migrations
{
    [DbContext(typeof(SmartStoreDbContext))]
    partial class SmartStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SmartStore.Domain.Model.Models.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("SmartStore.Domain.Model.Models.ItemPedido", b =>
                {
                    b.Property<Guid>("ProdutoId");

                    b.Property<Guid>("PedidoId");

                    b.Property<double>("Desconto")
                        .HasColumnType("double(10,2)");

                    b.Property<Guid>("Id")
                        .HasColumnName("Id");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int(10)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProdutoId", "PedidoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("ItemPedidos");
                });

            modelBuilder.Entity("SmartStore.Domain.Model.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("Instante")
                        .HasColumnType("DateTime(0)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("SmartStore.Domain.Model.Models.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Marca")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Tag")
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SmartStore.Domain.Model.Models.ProdutoCategoria", b =>
                {
                    b.Property<Guid>("ProdutoId");

                    b.Property<Guid>("CategoriaId");

                    b.Property<Guid>("Id");

                    b.HasKey("ProdutoId", "CategoriaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("ProdutoCategoria");
                });

            modelBuilder.Entity("SmartStore.Domain.Model.Models.ItemPedido", b =>
                {
                    b.HasOne("SmartStore.Domain.Model.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartStore.Domain.Model.Models.Produto", "Produto")
                        .WithMany("Pedidos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SmartStore.Domain.Model.Models.ProdutoCategoria", b =>
                {
                    b.HasOne("SmartStore.Domain.Model.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SmartStore.Domain.Model.Models.Produto", "Produto")
                        .WithMany("Categorias")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
