using System;
using System.Collections.Generic;

namespace SmartStore.Domain.Model.Models
{
    public class Produto : TEntity<Guid>
    {
        public string Tag { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public virtual ICollection<ItemPedido> Pedidos { get; set; }
        public virtual ICollection<ProdutoCategoria> Categorias { get; set; }

        public Produto()
        {
            Pedidos = new HashSet<ItemPedido>();
            Categorias = new HashSet<ProdutoCategoria>();
        }
    }
}
