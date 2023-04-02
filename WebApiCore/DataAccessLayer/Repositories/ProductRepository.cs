using Dapper;
using DataAccessLayer.Context;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using System.Data;
using System.Data.SqlTypes;

namespace WebApiCore.DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly DapperContext context;

        public ProductRepository(DapperContext _context) => context = _context;

        public Product GetProductById(int id)
        {
            using (var connection = context.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Product>("Product_GetProduct", new { ProductId = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var connection = context.CreateConnection())
            {
                return connection.Query<Product>("Product_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
