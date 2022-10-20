using RestDDD.Application.DTOS;
using RestDDD.Domain.Entities;
using RestDDD.Infraestructure.CrossCutting.Intercafes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestDDD.Infraestructure.CrossCutting.Mapper
{
    public class MapperCliente : IMapperCliente
    {
        //IEnumerable<ClienteDTO> clienteDTO = new List<ClienteDTO>();
        public Cliente MapperDTOEntity(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente() {
                id          =        clienteDTO.Id    ,
                Nome        =      clienteDTO.Nome    ,
                Sobrenome   = clienteDTO.SobreNome    ,
                Email       =     clienteDTO.Email
            };

            return cliente;
        }

        public ClienteDTO MapperEntityToDTO(Cliente cliente)
        {
            var clienteDTO = new ClienteDTO()
            {
                Id          =     cliente.id    ,
                Nome        =     cliente.Nome  ,
                SobreNome   = cliente.Sobrenome ,
                Email       =     cliente.Email
            };

            return clienteDTO;
        }

        public IEnumerable<ClienteDTO> MapperListClientesDTO(IEnumerable<Cliente> clientes)
        {
            var dto = clientes.Select(c => new ClienteDTO { 
                Id          = c.id          ,
                Nome        = c.Nome        ,
                SobreNome   = c.Sobrenome   ,
                Email       = c.Email
            });

            return dto;
        }
    }
}
