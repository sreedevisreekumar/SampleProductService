using SampleProductService.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProductService.Data.Interfaces
{
   public interface IProductRepository
    {
        IEnumerable<Product> GetProductsByCategory(string id);
        Product AddProductToCategory(string productId, string categoryId);
    }
}
