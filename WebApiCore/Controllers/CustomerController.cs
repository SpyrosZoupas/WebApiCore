using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCore.DataAccessLayer.Repositories;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpPost("create")]
        public void CreateCustomer(Customer customer)
        {
            customerRepository.CreateCustomer(customer);
        }

        [HttpGet("all")]
        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public Customer GetCustomerById(int id)
        {
            return customerRepository.GetCustomerById(id);
        }

        [HttpDelete("delete")]
        public void DeleteCustomerById(int id)
        {
            customerRepository.DeleteCustomer(id);
        }

        [HttpPut("update")]
        public void UpdateCustomer(Customer customer)
        {
            customerRepository.UpdateCustomer(customer);
        }

    }
}
