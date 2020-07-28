using System;
using System.Collections.Generic;

namespace SmartStore.Domain.Model.Models
{
    public class Categoria : TEntity<Guid>
    {
        public string Nome { get; set; }
        public virtual ICollection<ProdutoCategoria> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new HashSet<ProdutoCategoria>();
        }
    }
}