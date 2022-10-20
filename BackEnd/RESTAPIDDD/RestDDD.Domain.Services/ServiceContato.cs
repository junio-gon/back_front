using RestDDD.Domain.Core.Interfaces.Repositories;
using RestDDD.Domain.Core.Interfaces.Services;
using RestDDD.Domain.Entities;

namespace RestDDD.Domain.Services
{
    public class ServiceContato : ServiceBase<Contato>, IServiceContato
    {
        private readonly IRepositoryContato repositoryContato;

        public ServiceContato(IRepositoryContato repositoryContato) : base(repositoryContato)
        {
            this.repositoryContato = repositoryContato;
        }
    }
}
