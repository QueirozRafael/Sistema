using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaLoja.Models
{
    public class FornecedorProduto
    {
        [Key]
        public Int32 FornecedorProdutoId { get; set; }

        public Int32 FornecedorId { get; set; }

        public Int32 ProdutoId { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Produto Produto { get; set; }
            
    }
}