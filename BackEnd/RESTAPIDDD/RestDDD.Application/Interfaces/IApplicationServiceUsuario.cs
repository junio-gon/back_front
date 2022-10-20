using RestDDD.Application.DTOS;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        void Add(UsuarioDTO usuarioDTO);

        void Update(UsuarioDTO usuarioDTO);

        void Remove(UsuarioDTO usuarioDTO);

        IEnumerable<UsuarioDTO> GetAll();

        UsuarioDTO GetById(int id);
    }
}
