using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        //void Remove(TEntity obj);
        void Remove(int id);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
