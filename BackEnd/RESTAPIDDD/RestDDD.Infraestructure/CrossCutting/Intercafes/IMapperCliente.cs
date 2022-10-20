using RestDDD.Application.DTOS;
using RestDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Infraestructure.CrossCutting.Intercafes
{
    public interface IMapperCliente
    {
        Cliente MapperDTOEntity(ClienteDTO clienteDTO);
        IEnumerable<ClienteDTO> MapperListClientesDTO(IEnumerable<Cliente> clientes);
        ClienteDTO MapperEntityToDTO(Cliente cliente);
    }
}
