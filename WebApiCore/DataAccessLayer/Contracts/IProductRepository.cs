using DataAccessLayer.Models;
using System.Data;
using System.Data.SqlTypes;

namespace DataAccessLayer.Contracts
{
    public interface IProductRepository
    {
        public Product GetProductById(int id);
        public List<Product> GetAllProducts();
    }
}
