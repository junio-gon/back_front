using RestDDD.Application.DTOS;
using RestDDD.Application.Interfaces.Mappers;
using RestDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Application.Mappers
{
    public class MapperUsuario : IMapperUsuario
    {
        //IEnumerable<ClienteDTO> clienteDTO = new List<ClienteDTO>();

        public Usuario MapperDTOtoEntity(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario()
            {
                Email = usuarioDTO.Email,
                Password = usuarioDTO.Password
            };

            return usuario;
        }

        public UsuarioDTO MapperEntityToDTO(Usuario usuarios)
        {
            var usuarioDTO = new UsuarioDTO()
            {
                Email = usuarios.Email,
                Password = usuarios.Password
            };

            return usuarioDTO;
        }

        /*public IEnumerable<UsuarioDTO> MapperListUsuariosDTO(IEnumerable<Usuario> usuario)
        {
            var dto = usuarios.Select(usuario => new UsuarioDTO
            {
                Email = usuario.Email,
                Password = usuario.Password
            });

            return dto;
        }*/

        public IEnumerable<UsuarioDTO> MapperListUsuariosDTO(IEnumerable<Usuario> usuario)
        {
            throw new NotImplementedException();
        }
    }
}
