using Microsoft.EntityFrameworkCore;
using SampleProductService.Data.DBContexts;
using SampleProductService.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleProductService.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext applicationDBContext;

        public UnitOfWork(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }
        public void Commit()
        {
            this.applicationDBContext.SaveChanges();
        }

        public void Dispose()
        {
            this.applicationDBContext.Dispose();
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            GenericRepository<T> genericRepository = new GenericRepository<T>(applicationDBContext);
            return genericRepository;
        }
    }
}
