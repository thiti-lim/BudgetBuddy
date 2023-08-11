using BudgetBuddy.Data;
using BudgetBuddy.Data.DomainModels;
using BudgetBuddy.Repositories.Interfaces;
using BudgetBuddy.ViewModels;
using Microsoft.Identity.Web;

namespace BudgetBuddy.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ISqlDataAccess db;
		private readonly IHttpContextAccessor contextAccessor;
		private Guid currentUserId; 

		public CustomerRepository(ISqlDataAccess db, IHttpContextAccessor contextAccessor)
		{
			this.db = db;
			this.contextAccessor = contextAccessor;
			string? oid = contextAccessor?.HttpContext?.User.GetObjectId() ?? null;
			if (oid is not null) currentUserId = new Guid(oid);  
		}

		public Task<IEnumerable<Customer>> GetCustomers()
		{
			string sql = $"SELECT * FROM dbo.Customers WHERE UserId = '{currentUserId}'";
			return db.LoadData<Customer, dynamic>(sql, new { }); 
		}

		public Task InsertCustomer(CustomerViewModel customer)
		{
			string sql = @"INSERT INTO dbo.Customer (UserId, CustomerName) VALUES (@UserId, @CustomerName);"; 
			Customer c = new Customer
			{
				UserId = currentUserId,
				CustomerName = customer.CustomerName,
			};

			return db.SaveData(sql, c); 
		}


	}
}
