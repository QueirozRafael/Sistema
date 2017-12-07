using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Ordem
    {
        [Key]
        public Int32 OrdemId { get; set; }

        public DateTime DataOrdem { get; set; }

        public Int32 CustomizarId { get; set; }

        public OrdemStatus OrdemStatus { get; set; }

        public virtual Customizar Customizar { get; set; }

        public virtual ICollection<OrdemDetalhe> OrdemDetalhe { get; set; }
    }
}