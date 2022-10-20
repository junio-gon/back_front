using RestDDD.Application.DTOS;
using RestDDD.Application.Interfaces.Mappers;
using RestDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestDDD.Application.Mappers
{
    public class MapperContato : IMappersContato
    {
        public Contato MapperDTOtoEntity(ContatoDTO contatoDTO)
        {
            var contato = new Contato()
            {
                Id = contatoDTO.Id,
                Nome = contatoDTO.Nome,
                Nascimento = contatoDTO.Nascimento,
                Email = contatoDTO.Email
            };

            return contato;
        }

        public ContatoDTO MapperEntityToDTO(Contato contato)
        {
            if (contato != null)
            {
                var contatoDTO = new ContatoDTO()
                {
                    Id = contato.Id,
                    Nome = contato.Nome,
                    Nascimento = contato.Nascimento,
                    Email = contato.Email
                };
                return contatoDTO;
            }
            else
            {
                return null;
            }
                
        }

        public IEnumerable<ContatoDTO> MapperListContatosDTO(IEnumerable<Contato> contatos)
        {
            var dto = contatos.Select(c => new ContatoDTO
            {
                Id = c.Id,
                Nome = c.Nome,
                Nascimento = c.Nascimento,
                Email = c.Email
            });

            return dto;
        }
    }
}
