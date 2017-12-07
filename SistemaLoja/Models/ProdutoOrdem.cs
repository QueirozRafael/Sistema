using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class ProdutoOrdem : Produto
    {
        [Required]
        public Int32 Quantidade { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public Decimal Valor { get { return Preco * Quantidade; } }
    }
}