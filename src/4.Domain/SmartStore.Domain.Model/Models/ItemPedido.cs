using System;

namespace SmartStore.Domain.Model.Models
{
    public class ItemPedido : TEntity<Guid>
    {
        public Guid ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public Guid PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public double Desconto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
