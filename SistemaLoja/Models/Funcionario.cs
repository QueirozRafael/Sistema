using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLoja.Models
{
    public class Funcionario
    {
        [Key]
        public Int32 FuncionarioId { get; set; }
        [DisplayName("Nome")]
        [Required]
        public String Nome { get; set; }
        
        [DisplayName("Sobrenome")]
        [Required]
        public String Sobrenome { get; set; }

        [DisplayName("Nascimento")]
        [Required]
        public DateTime Nacimento { get; set; }

        [DisplayName("Email")]
        [Required]
        public String Email { get; set; }

        [DisplayName("Admissão")]
        [Required]
        public DateTime Admissao { get; set; }

        [DisplayName("Salário")]
        [Required]
        public Decimal Salario { get; set; }

        [DisplayName("Comissão")]
        [Required]
        public Double Comissao { get; set; }

        public virtual TipoDocumento TipoDocumento { get; set; }
    }
}