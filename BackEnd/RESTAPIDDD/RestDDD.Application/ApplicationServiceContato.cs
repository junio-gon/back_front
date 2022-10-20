using RestDDD.Application.DTOS;
using RestDDD.Application.Interfaces;
using RestDDD.Application.Interfaces.Mappers;
using RestDDD.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace RestDDD.Application
{
    public class ApplicationServiceContato : IApplicationServiceContato
    {
        private readonly IServiceContato _serviceContato;
        private readonly IMappersContato _mapperContato;

        public ApplicationServiceContato(IServiceContato serviceContato, IMappersContato mapperContato)
        {
            _serviceContato = serviceContato;
            _mapperContato = mapperContato;
        }
        public void Add(ContatoDTO contatoDTO)
        {
            var contato = _mapperContato.MapperDTOtoEntity(contatoDTO);
            _serviceContato.Add(contato);
        }

        public IEnumerable<ContatoDTO> GetAll()
        {
            var contatos = _serviceContato.GetAll();
            return _mapperContato.MapperListContatosDTO(contatos);
        }

        public ContatoDTO GetById(int id)
        {
            var contato = _serviceContato.GetById(id);
            return _mapperContato.MapperEntityToDTO(contato);
        }

        /*public void Remove(ContatoDTO clienteDTO)
        {
            var contato = _mapperContato.MapperDTOtoEntity(clienteDTO);
            _serviceContato.Remove(contato);
        }*/
        public void Remove(int id)
        {
            //var contato = _mapperContato.MapperDTOtoEntity(clienteDTO);
            _serviceContato.Remove(id);
        }

        public void Update(ContatoDTO contatoDTO)
        {
            var contato = _mapperContato.MapperDTOtoEntity(contatoDTO);
            _serviceContato.Upadate(contato);
        }
    }
}
