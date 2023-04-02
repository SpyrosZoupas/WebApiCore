using Dapper;
using DataAccessLayer.Context;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using System.Data;

namespace WebApiCore.DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly DapperContext context;

        public OrderRepository(DapperContext _context) => context = _context;

        public void CreateOrder(Order order)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@SubmissionDate", order.SubmissionDate);
            parameters.Add("@ArrivalDate", order.ArrivalDate);

            using (var connection = context.CreateConnection())
            {
                connection.Query("Order_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteOrder(int id)
        {
            using (var connection = context.CreateConnection())
            {
                connection.Query("Order_Delete", new { ID = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Order> GetAllOrders()
        {
            using (var connection = context.CreateConnection())
            {
                List<Order> orders = connection.Query<Order>("Order_GetAll", commandType: CommandType.StoredProcedure).ToList();
                return orders;
            }
        }

        public Order GetOrderById(int id)
        {
            using (var connection = context.CreateConnection())
            {
                Order order = connection.QueryFirstOrDefault<Order>("Order_GetOrder", new { Id = id }, commandType: CommandType.StoredProcedure);
                return order;
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", order.OrderId);
                parameters.Add("@SubmissionDate", order.SubmissionDate);
                parameters.Add("@ArrivalDate", order.ArrivalDate);
                //CustomerId??

                connection.QueryFirstOrDefaultAsync("Order_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
