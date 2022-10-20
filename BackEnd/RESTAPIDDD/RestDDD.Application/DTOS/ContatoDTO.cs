using System;

namespace RestDDD.Application.DTOS
{
    public class ContatoDTO
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }

        public string Email { get; set; }
    }
}
