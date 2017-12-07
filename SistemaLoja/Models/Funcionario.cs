using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Funcionario
    {
        [Key]
        public Int32 FuncionarioId { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public String Nome { get; set; }

        [DisplayName("Sobrenome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public String Sobrenome { get; set; }

        [DisplayName("Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }

        [NotMapped] //campo cálculado
        public Int32 Idade { get { return DateTime.Now.Year - Nascimento.Year; } }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [DisplayName("Admissão")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Admissao { get; set; }

        [DisplayName("Salário")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:C2}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Decimal Salario { get; set; }

        [DisplayName("Comissão")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:P2}")]
        public Double? Comissao { get; set; }

        [DisplayName("Tipo Documento")]
        public Int32 TipoDocumentoId { get; set; }
                
        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}