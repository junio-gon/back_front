using System;
using System.ComponentModel.DataAnnotations;

namespace RestDDD.Domain.Entities
{
    public class Contato : Base
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        public bool IsActive { get; set; }
    }
}
