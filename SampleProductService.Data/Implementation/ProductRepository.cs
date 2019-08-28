using Microsoft.EntityFrameworkCore;
using SampleProductService.Data.DBContexts;
using SampleProductService.Data.Interfaces;
using SampleProductService.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleProductService.Data.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DbContext _dbContext;

        public ProductRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext)
        {
            this._dbContext = applicationDBContext;
        }

        public Product AddProductToCategory(string productId, string categoryId)
        {
            var product = _dbContext.Set<Product>().Find(Convert.ToInt32(productId));
            if(product!=null)
            {
                product.CategoryId = Convert.ToInt32(categoryId);
                this._dbContext.Set<Product>().Attach(product);
                this._dbContext.Entry(product).State = EntityState.Modified;
            }
            return product;
        }

        public IEnumerable<Product> GetProductsByCategory(string id)
        {
            var products = _dbContext.Set<Product>().Where(p => p.CategoryId == Convert.ToInt32(id)).ToList();
            return products;
        }
    }
}
