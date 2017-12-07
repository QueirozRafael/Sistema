using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class OrdemDetalhe
    {
        [Key]
        public Int32 OrdemDetalheId { get; set; }

        public Int32 OrdemId { get; set; }

        public Int32 ProdutoId { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public String Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public Decimal Preco { get; set; }

        [Required]
        public Int32 Quantidade { get; set; }

        public virtual Ordem Ordem { get; set; }
        public virtual Produto Produto { get; set; }

    }
}