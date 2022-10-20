using RestDDD.Application.DTOS;
using RestDDD.Application.Interfaces;
using RestDDD.Application.Interfaces.Mappers;
using RestDDD.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Application
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {

        private readonly IServiceUsuario serviceUsuario;
        private readonly IMapperUsuario mapperUsuario;

        public ApplicationServiceUsuario(IServiceUsuario serviceUsuario, IMapperUsuario mapperUsuario)
        {
            this.serviceUsuario = serviceUsuario;
            this.mapperUsuario = mapperUsuario;
        }

        public void Add(UsuarioDTO usuarioDTO)
        {
            var usuario = mapperUsuario.MapperDTOtoEntity(usuarioDTO);
            this.serviceUsuario.Add(usuario);
        }

        public void Remove(UsuarioDTO usuarioDTO)
        {
            var usuario = mapperUsuario.MapperDTOtoEntity(usuarioDTO);
            //serviceUsuario.Remove(usuario);
        }

        public void Update(UsuarioDTO usuarioDTO)
        {
            var usuario = mapperUsuario.MapperDTOtoEntity(usuarioDTO);
            serviceUsuario.Upadate(usuario);
        }

        IEnumerable<UsuarioDTO> IApplicationServiceUsuario.GetAll()
        {
            throw new NotImplementedException();
            /*var usuarios = serviceUsuario.GetAll();
            return this.mapperUsuario.MapperListUsuariosDTO(usuarios);*/
        }

        UsuarioDTO IApplicationServiceUsuario.GetById(int id)
        {
            var usuario = serviceUsuario.GetById(id);
            return this.mapperUsuario.MapperEntityToDTO(usuario);
        }
    }
}
