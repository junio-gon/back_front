using RestDDD.Domain.Core.Interfaces.Repositories;
using RestDDD.Domain.Entities;

namespace RestDDD.Infraestructure.Data.Repositories
{
    public class RepositoryContato : RepositoryBase<Contato>, IRepositoryContato
    {
        private readonly SqlContext sqlContext;

        public RepositoryContato(SqlContext sqlContext) : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }
    }
}
