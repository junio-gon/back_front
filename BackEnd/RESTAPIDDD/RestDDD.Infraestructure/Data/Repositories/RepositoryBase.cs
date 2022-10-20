using RestDDD.Domain.Core.Interfaces.Repositories;
using RestDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestDDD.Infraestructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                sqlContext.Set<TEntity>().Add(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return sqlContext.Set<TEntity>().ToList();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return sqlContext.Set<TEntity>().Find(id);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        /*public void Remove(TEntity obj)
        {
            try
            {
                sqlContext.Set<TEntity>().Remove(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/

        public void Remove(int id)
        {
            try
            {
                Contato contato = new Contato();
                contato = sqlContext.Set<Contato>().Find(id);
                sqlContext.Entry(contato).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
