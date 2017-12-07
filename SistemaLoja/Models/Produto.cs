using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaLoja.Models
{
    public class Produto
    {
        [Key]
        public Int32 ProdutoId { get; set; }

        [DisplayName("Descrição")]
        [Required]
        public String Descricao { get; set; }

        [DisplayName("Preço")]
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public Decimal Preco { get; set; }

        [DisplayName("Última Compra")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime UltimaCompra { get; set; }
        
        [DisplayName("Estoque")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public Int32 Estoque { get; set; }

        [DisplayName("Ativo")]
        [Required]
        public Boolean Ativo { get; set; }

        [DisplayName("Comentário")]
        [DataType(DataType.MultilineText)]
        public String Comentario { get; set; }
        
        public virtual ICollection<FornecedorProduto> FornecedorProduto { get; set; }
        public virtual ICollection<OrdemDetalhe> OrdemDetalhe { get; set; }
    }
}