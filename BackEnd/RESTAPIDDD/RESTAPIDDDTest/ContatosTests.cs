using System;
using Xunit;
using RestDDD.API.Controllers;
using RestDDD.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using RestDDD.Domain.Entities.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using RestDDD.API.Properties;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using RestDDD.Application;
using RestDDD.Application.DTOS;
using RestDDD.Application.Mappers;
using RestDDD.Domain.Services;
using RestDDD.Infraestructure.Data.Repositories;
using RestDDD.Infraestructure.Data;
using System.Net;

namespace RESTAPIDDDTest
{
    public class ContatosTests
    {
        private static IConfigurationRoot _appSettings => setConfigurations();
        private static SqlContext _context = new SqlContext(_appSettings.GetConnectionString(_appSettings.GetValue(typeof(string), "Environment").ToString()));
        private static RepositoryContato _repository = new RepositoryContato(_context);
        private static MapperContato _mapperContato = new MapperContato();
        private static ServiceContato _serviceContato = new ServiceContato(_repository);
        private static ApplicationServiceContato _applicationServiceContato = new ApplicationServiceContato(_serviceContato, _mapperContato);
        private static ContatosController _contatoController = new ContatosController(_applicationServiceContato);

        [Fact]
        public void Criar_Contato()
        {
            var result = _contatoController.CreateContato(mockContato());
            var resultValue = Assert.IsType<OkObjectResult>(result);
            Assert.True(resultValue.StatusCode == (int)HttpStatusCode.OK);
        }

        [Fact]
        public void Nao_Deve_Criar_Caso_Obj_Seja_Nulo()
        {
            var result = _contatoController.CreateContato(null);
            Assert.Equal(typeof(BadRequestObjectResult), result.GetType());
        }

        [Fact]
        public void Consultar_Lista_De_Contatos()
        {
            var result = _contatoController.GetContatosListAll();
            Assert.True(result.Result != null);
        }

        [Theory]
        [InlineData((int) 1)]
        public void Consultar_Contato_Por_Id(int id)
        {
            var result = _contatoController.GetContatoById(1);
            Assert.True(result.Result != null);
        }

        [Fact]
        public void Atualizar_Dados_Do_Contato()
        {
            var result = _contatoController.UpdateContato(mockContatoUpdate());
            var resultValue = Assert.IsType<OkObjectResult>(result);
            Assert.True(resultValue.StatusCode == (int)HttpStatusCode.OK);
        }

        [Theory]
        [InlineData("3")]
        public void Excluir_Contato_Por_Id(string id)
        {
            var result = _contatoController.DeleteContatoById(id);
            var resultValue = Assert.IsType<OkObjectResult>(result);
            Assert.True(resultValue.StatusCode == (int)HttpStatusCode.OK);
        }

        private static IConfigurationRoot setConfigurations()
        {
            return new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();
        }

        private ContatoDTO mockContato()
        {
            return new ContatoDTO
            {
                Nome = "João Paulo",
                Nascimento = DateTime.Now,
                Email = "joao@paulo.com.br"
            };
        }

        private ContatoDTO mockContatoUpdate()
        {
            return new ContatoDTO
            {
                Id = 2,
                Nome = "João Paulo",
                Nascimento = DateTime.Now,
                Email = "joao@paulo.com.br"
            };
        }
    }
}
