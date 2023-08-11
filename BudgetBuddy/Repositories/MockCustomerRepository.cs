using BudgetBuddy.Data;
using BudgetBuddy.Data.DomainModels;
using BudgetBuddy.Repositories.Interfaces;
using BudgetBuddy.Shared;
using BudgetBuddy.ViewModels;
using Microsoft.Identity.Web;
using System.Security.Claims;

namespace BudgetBuddy.Repositories
{
	public class MockCustomerRepository : ICustomerRepository
	{
		private readonly ISqlDataAccess db;
        private readonly IHttpContextAccessor contextAccessor;
        private IEnumerable<Customer> customersInMemory;
		private ClaimsPrincipal? currentPrincipal; 
		private string? currentPrincipalId; 
		private Guid mockUserId1;
		private Guid mockUserId2;

		public MockCustomerRepository(ISqlDataAccess db, IHttpContextAccessor contextAccessor)
		{
			this.db = db;
			this.contextAccessor = contextAccessor; 
			if (contextAccessor.HttpContext is not null && contextAccessor.HttpContext.User is not null)
            {
			currentPrincipal = contextAccessor.HttpContext.User; 
            }  
			if (currentPrincipal is not null)
            {
				currentPrincipalId = currentPrincipal.GetObjectId();
            }

			if (currentPrincipalId is not null)
			{
				mockUserId1 = new Guid(currentPrincipalId);

			}
			mockUserId2 = Guid.NewGuid();




            this.customersInMemory = new List<Customer> {
				new Customer { CustomerName = "Customer A1", UserId = mockUserId1 },
				new Customer {  CustomerName = "Customer B1", UserId = mockUserId1 },
				new Customer { CustomerName = "Customer C1", UserId = mockUserId1 },
				new Customer { CustomerName = "Customer A2", UserId = mockUserId2 },
				new Customer { CustomerName = "Customer B2", UserId = mockUserId2 },
				new Customer {CustomerName = "Customer C2", UserId = mockUserId2 }
			};

		}

		public Task<IEnumerable<Customer>> GetCustomers()
		{
			return Task.FromResult(customersInMemory.Where(c => c.UserId == mockUserId1));
		}

		public Task<Customer?> GetCustomerById(int id)
		{
			return Task.FromResult(customersInMemory.FirstOrDefault());
		}

		public Task InsertCustomer(CustomerViewModel customer)
		{
			Customer c = new Customer
			{
				UserId = mockUserId1,
				CustomerName = customer.CustomerName
			};
			customersInMemory = customersInMemory.Append(c);
			return GetCustomers();


		}
	}
}
