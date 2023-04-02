using Dapper;
using DataAccessLayer.Models;
using System.Data;

namespace DataAccessLayer.Contracts
{
    public interface ICustomerRepository
    {
        void CreateCustomer(Customer customer);

        void DeleteCustomer(int id);

        List<Customer> GetAllCustomers();

        Customer GetCustomerById(int id);

        void UpdateCustomer(Customer customer);
    }
}
