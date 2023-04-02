using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.DataAccessLayer.Repositories;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return productRepository.GetProductById(id);
        }

        [HttpGet("all")]
        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }
    }
}
