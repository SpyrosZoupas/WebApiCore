using Dapper;
using DataAccessLayer.Models;
using System.Data;

namespace DataAccessLayer.Contracts
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
        public void DeleteOrder(int id);
        public List<Order> GetAllOrders();
        public Order GetOrderById(int id);
        public void UpdateOrder(Order order);
    }
}

