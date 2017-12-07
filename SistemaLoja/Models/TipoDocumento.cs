using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class TipoDocumento
    {
        [Key]
        public Int32 TipoDocumentoId { get; set; }

        [DisplayName("Tipo Documento")]
        [Required]
        public String Descricao { get; set; }

        public virtual ICollection<Funcionario> Funcionario { get; set; }

        public virtual ICollection<Customizar> Customizacao { get; set; }
    }
}