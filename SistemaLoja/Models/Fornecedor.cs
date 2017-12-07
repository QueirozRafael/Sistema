using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaLoja.Models
{
    public class Fornecedor
    {
        [Key]
        public Int32 FornecedorId { get; set; }

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

        public virtual ICollection<FornecedorProduto> FornecedorProduto { get; set; }
    }
}