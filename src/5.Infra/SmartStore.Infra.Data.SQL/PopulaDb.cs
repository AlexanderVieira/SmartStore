using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SmartStore.Domain.Model.Models;
using SmartStore.Infra.Data.SQL.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartStore.Infra.Data.SQL
{
    public static class PopulaDb
    {        
        public static void InserirDadosDb(SmartStoreDbContext context)
        {
            Console.WriteLine("Aplicando Migrations...");
            context.Database.Migrate();

            if (!context.Produtos.Any())
            {
                Console.WriteLine("Criando dados...");

                List<Produto> produtos = new List<Produto>();
                var prodSmartphoneSamsung = new Produto { Id = Guid.NewGuid(), Tag = "1971C36E", Marca = "Samsung", Modelo = "Smartphone A10s", Descricao = "Memória RAM: 2GB", Valor = 949.00m };
                var prodSmartphoneLG = new Produto { Id = Guid.NewGuid(), Tag = "E12B6320", Marca = "LG", Modelo = "Smartphone K50s", Descricao = "Memória RAM: 3GB", Valor = 989.00m };
                produtos.Add(prodSmartphoneSamsung);
                produtos.Add(prodSmartphoneLG);

                var categoriaTelefonia = new Categoria { Id = Guid.NewGuid(), Nome = "Telefonia" };

                var pedido = new Pedido { Id = Guid.NewGuid(), Instante = DateTime.Now };

                List<ItemPedido> itemPedidos = new List<ItemPedido>();
                var itemPedido1 = new ItemPedido { Id = Guid.NewGuid(), PedidoId = pedido.Id, ProdutoId = prodSmartphoneSamsung.Id, Desconto = 0.00, Quantidade = 1, Produto = prodSmartphoneSamsung, Pedido = pedido, Valor = prodSmartphoneSamsung.Valor };
                var itemPedido2 = new ItemPedido { Id = Guid.NewGuid(), PedidoId = pedido.Id, ProdutoId = prodSmartphoneLG.Id, Desconto = 0.00, Quantidade = 1, Produto = prodSmartphoneLG, Pedido = pedido, Valor = prodSmartphoneLG.Valor };
                itemPedidos.Add(itemPedido1);
                itemPedidos.Add(itemPedido2);
                
                pedido.Itens = itemPedidos;
                pedido.Total = itemPedidos.Sum(x => x.Valor);

                List<ProdutoCategoria> telefoniaProdutoCategorias = new List<ProdutoCategoria>();
                var produtoCategoria1 = new ProdutoCategoria { Id = Guid.NewGuid(), ProdutoId = prodSmartphoneSamsung.Id, CategoriaId = categoriaTelefonia.Id, Produto = prodSmartphoneSamsung, Categoria = categoriaTelefonia };
                var produtoCategoria2 = new ProdutoCategoria { Id = Guid.NewGuid(), ProdutoId = prodSmartphoneLG.Id, CategoriaId = categoriaTelefonia.Id, Produto = prodSmartphoneLG, Categoria = categoriaTelefonia };
                telefoniaProdutoCategorias.Add(produtoCategoria1);
                telefoniaProdutoCategorias.Add(produtoCategoria2);
                
                categoriaTelefonia.Produtos = telefoniaProdutoCategorias;

                context.Produtos.AddRange(produtos);
                context.Categorias.AddRange(categoriaTelefonia);
                context.Pedidos.AddRange(pedido);
                context.ItemPedidos.AddRange(itemPedidos);
                context.ProdutoCategorias.AddRange(telefoniaProdutoCategorias);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Dados já existem...");
            }
        }
    }
}
