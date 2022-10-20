using RestDDD.Application.DTOS;
using System.Collections.Generic;

namespace RestDDD.Application.Interfaces
{
    public interface IApplicationServiceContato
    {
        void Add(ContatoDTO contatoDTO);

        void Update(ContatoDTO contatoDTO);

        //void Remove(ContatoDTO contatoDTO);
        void Remove(int id);

        IEnumerable<ContatoDTO> GetAll();

        ContatoDTO GetById(int id);
    }
}
