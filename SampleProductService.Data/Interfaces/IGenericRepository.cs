using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProductService.Data.Interfaces
{
   public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> Get();
        T GetById(string Id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
