using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Customizar
    {
        [Key]
        public Int32 CustomizarId { get; set; }

        [Required]
        public String Nome { get; set; }

        public String Sobrenome { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public String Telefone { get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public String Endereco { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Display(Name = "Documento")]
        public String Documento { get; set; }

        [Required]
        [Display(Name = "Tipo Documento")]
        public Int32 TipoDocumentoId { get; set; }

        public String NomeCompleto { get { return String.Format("{0} {1}", Nome, Sobrenome); } }

        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual ICollection<Ordem> Ordem { get; set; }
    }
}