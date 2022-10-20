using RestDDD.Domain.Core.Interfaces.Repositories;
using RestDDD.Domain.Core.Interfaces.Services;
using RestDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario repositoryusuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario) : base(repositoryUsuario)
        {
            this.repositoryusuario = repositoryUsuario;
        }
    }
}
