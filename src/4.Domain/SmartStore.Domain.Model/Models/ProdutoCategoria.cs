using System;

namespace SmartStore.Domain.Model.Models
{
    public class ProdutoCategoria : TEntity<Guid>
    {
        public Guid ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}