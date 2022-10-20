using Autofac;
using Microsoft.AspNetCore.Identity;
using RestDDD.Application;
using RestDDD.Application.Interfaces;
using RestDDD.Application.Interfaces.Mappers;
using RestDDD.Application.Mappers;
using RestDDD.Domain.Core.Interfaces.Repositories;
using RestDDD.Domain.Core.Interfaces.Services;
using RestDDD.Domain.Services;
using RestDDD.Infraestructure.Data.Repositories;

namespace RestDDD.Infraestructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            //apllications Services
            builder.RegisterType<ApplicationServiceContato>().As<IApplicationServiceContato>();
            builder.RegisterType<ApplicationServiceUsuario>().As<IApplicationServiceUsuario>();
            builder.RegisterType<IdentityUser>();

            //Services
            builder.RegisterType<ServiceContato>().As<IServiceContato>();
            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();

            //Repositories
            builder.RegisterType<RepositoryContato>().As<IRepositoryContato>();
            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();

            //Mappers
            builder.RegisterType<MapperContato>().As<IMappersContato>();
            builder.RegisterType<MapperUsuario>().As<IMapperUsuario>();
            #endregion
        }
    }
}
