using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStoreApi.Application.Interfaces;
using TechStoreApi.Domain.Models;

namespace TechStoreApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public ActionResult<Response<int>> Create([FromBody] Product product)
        {
            var response = _productService.Create(product);
            return response;
        }
        [HttpGet]
        public ActionResult<Response<List<Product>>> GetAll()
        {
            var response = _productService.GetAll();
            return response;
        }
    }
}