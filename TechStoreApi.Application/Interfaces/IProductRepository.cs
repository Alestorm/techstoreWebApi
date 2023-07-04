using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStoreApi.Domain.Models;

namespace TechStoreApi.Application.Interfaces
{
    public interface IProductRepository
    {
        Response<int> Create(Product product);
        Response<List<Product>> GetAll();
        Response<Product> Get(int id);
    }
}