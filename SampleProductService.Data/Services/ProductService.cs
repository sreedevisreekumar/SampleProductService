using SampleProductService.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProductService.Data.Services
{
   public class ProductService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
