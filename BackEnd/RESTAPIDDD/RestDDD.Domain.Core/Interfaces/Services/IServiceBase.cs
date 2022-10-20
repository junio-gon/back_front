using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Upadate(TEntity obj);

        //void Remove(TEntity obj);
        void Remove(int id);
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);
    }
}
