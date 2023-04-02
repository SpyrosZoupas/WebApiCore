using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.DataAccessLayer.Repositories;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpPost("create")]
        public void CreateOrder([FromBody]Order order)
        {
            orderRepository.CreateOrder(order);
        }

        [HttpGet("all")]
        public List<Order> GetAllOrders()
        {
            return orderRepository.GetAllOrders();
        }

        [HttpDelete("delete/{id}")]
        public void DeleteOrder(int id)
        {
            orderRepository.DeleteOrder(id);
        }

        [HttpGet("{id}")]
        public void GetOrderById(int id)
        {
            orderRepository.GetOrderById(id);
        }

        [HttpPut("update")]
        public void UpdateOrder(Order order)
        {
            orderRepository.UpdateOrder(order);
        }
    }
}
