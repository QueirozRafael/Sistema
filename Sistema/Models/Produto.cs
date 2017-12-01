using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema.Models
{
    public class Produto
    {
        [Key]
        public Int32 Id { get; set; }
        [DisplayName("Descrição")]
        [Required]
        public String Descricao { get; set; }
        [DisplayName("Preço")]
        [Required]
        public Decimal Preco { get; set; }
        [DisplayName("Última Compra")]
        [Required]
        public DateTime UltimaCompra { get; set; }
        [DisplayName("Estoque")]
        [Required]
        public Int32 Estoque { get; set; }
        [DisplayName("Ativo")]
        [Required]
        public Boolean Ativo { get; set; }
    }
}