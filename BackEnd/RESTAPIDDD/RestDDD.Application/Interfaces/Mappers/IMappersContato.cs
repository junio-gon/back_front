using RestDDD.Application.DTOS;
using RestDDD.Domain.Entities;
using System.Collections.Generic;

namespace RestDDD.Application.Interfaces.Mappers
{
    public interface IMappersContato
    {
        Contato MapperDTOtoEntity(ContatoDTO contatoDTO);
        IEnumerable<ContatoDTO> MapperListContatosDTO(IEnumerable<Contato> contatos);
        ContatoDTO MapperEntityToDTO(Contato contato);
    }
}
