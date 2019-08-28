using Microsoft.EntityFrameworkCore;
using SampleProductService.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleProductService.Data.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
            this.dbSet = this._dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public IEnumerable<T> Get()
        {
            return this.dbSet.ToList();
        }

        public T  GetById(string Id)
        {
          return  this.dbSet.Find(Id);
        }

        public void Update(T entity)
        {
            this.dbSet.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
