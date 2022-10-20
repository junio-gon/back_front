using RestDDD.Application.DTOS;
using RestDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Application.Interfaces.Mappers
{
    public interface IMapperUsuario
    {
        Usuario MapperDTOtoEntity(UsuarioDTO usuarioDTO);
        IEnumerable<UsuarioDTO> MapperListUsuariosDTO(IEnumerable<Usuario> usuario);
        UsuarioDTO MapperEntityToDTO(Usuario usuarios);
    }
}
