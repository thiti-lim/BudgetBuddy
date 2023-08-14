using BudgetBuddy.Data;
using BudgetBuddy.Data.DomainModels;
using BudgetBuddy.Repositories.Interfaces;
using Microsoft.Identity.Web;

namespace BudgetBuddy.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ISqlDataAccess db;
		private readonly IHttpContextAccessor contextAccessor;
		private string currentUserId; 

		public CustomerRepository(ISqlDataAccess db, IHttpContextAccessor contextAccessor)
		{
			this.db = db;
			this.contextAccessor = contextAccessor;
			string? oid = contextAccessor?.HttpContext?.User.GetObjectId() ?? null;
			if (oid is not null) currentUserId = oid;  
		}

		public Task<IEnumerable<Customer>> GetCustomers()
		{
			string sql = $"SELECT * FROM Customer WHERE UserId = '{currentUserId}'";
			return db.LoadData<Customer, dynamic>(sql, new { }); 
		}

		public Task InsertCustomer(Customer customer)
		{
			customer.UserId = currentUserId; 

			string sql = @"INSERT INTO Customer (UserId, CustomerName) VALUES (@UserId, @CustomerName);"; 
			return db.SaveData(sql, new {UserId = currentUserId, CustomerName = customer.CustomerName}); 
		}

		public Task UpdateCustomer(Customer customer)
		{
			string sql = $"UPDATE Customer SET CustomerName = @CustomerName where Id = @Id";
			return db.SaveData(sql, customer);
		}

		public Task DeleteCustomer(Customer customer)
		{
			string sql = $"DELETE FROM Customer WHERE Id = @Id";
			return db.SaveData(sql, customer); 
		}


	}
}
