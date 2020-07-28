using System;
using System.Collections.Generic;

namespace SmartStore.Domain.Model.Models
{
    public class Pedido : TEntity<Guid>
    {
        public DateTime Instante { get; set; }
        public decimal Total { get; set; }
        public virtual ICollection<ItemPedido> Itens { get; set; }

        public Pedido()
        {
            Itens = new HashSet<ItemPedido>();
        }
    }
}