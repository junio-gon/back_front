using RestDDD.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestDDD.Domain.Entities
{
    [NotMapped]
    public class Usuario : Base
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} esta em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(30, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} carateres", MinimumLength = 6)]
        public string Password { get; set; }

        /*[Compare("Password", ErrorMessage = "As senhas informadas são diferentes")]
        public string ConfirmPassword { get; set; }*/

        public TipoUsuario? Tipo { get; set; }
    }
}
