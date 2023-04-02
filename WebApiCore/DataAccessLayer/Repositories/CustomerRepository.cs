using Dapper;
using DataAccessLayer.Context;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using System.Data;


namespace WebApiCore.DataAccessLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly DapperContext context;

        public CustomerRepository(DapperContext _context) => context = _context;

        public void CreateCustomer(Customer customer)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", customer.FirstName);
            parameters.Add("@LastName", customer.LastName);
            parameters.Add("@Email", customer.Email);
            parameters.Add("@Password", customer.Password);
            parameters.Add("@PhoneNumber", customer.PhoneNumber);
            parameters.Add("@Address", customer.Address);

            using (var connection = context.CreateConnection())
            {
                connection.Query("Customer_Insert", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteCustomer(int id)
        {
            using (var connection = context.CreateConnection())
            {
                connection.Query("Customer_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public List<Customer> GetAllCustomers()
        {
            using (var connection = context.CreateConnection())
            {
                return connection.Query<Customer>("Customer_GetAll", commandType: CommandType.StoredProcedure).ToList();
                
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var connection = context.CreateConnection())
            {
                return connection.QueryFirstOrDefault<Customer>("Customer_GetCustomer", new { Id = id }, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (var connection = context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", customer.CustomerId);
                parameters.Add("@FirstName", customer.FirstName);
                parameters.Add("@LastName", customer.LastName);
                parameters.Add("@Email", customer.Email);
                parameters.Add("@Password", customer.Password);
                parameters.Add("@PhoneNumber", customer.PhoneNumber);
                parameters.Add("@Address", customer.Address);

                connection.Query("Customer_Update", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
