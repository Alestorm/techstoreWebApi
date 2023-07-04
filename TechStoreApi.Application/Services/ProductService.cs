using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStoreApi.Application.Interfaces;
using TechStoreApi.Domain.Models;

namespace TechStoreApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Response<int> Create(Product product)
        {
            var response = _productRepository.Create(product);
            return response;
        }

        public Response<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Response<List<Product>> GetAll()
        {
            var response = _productRepository.GetAll();
            return response;
        }
    }
}
