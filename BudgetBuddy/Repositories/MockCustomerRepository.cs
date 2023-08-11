using BudgetBuddy.Data;
using BudgetBuddy.Data.DomainModels;
using BudgetBuddy.Repositories.Interfaces;
using BudgetBuddy.Shared;
using BudgetBuddy.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;

namespace BudgetBuddy.Repositories
{
	public class MockCustomerRepository : ICustomerRepository
	{
		private readonly ISqlDataAccess db;
		private IEnumerable<Customer> customersInMemory;
		private Guid mockUserId1;
		private Guid mockUserId2;

		public MockCustomerRepository(ISqlDataAccess db, StateContainer state)
		{
			mockUserId1 = state.CurrentUserId;
			mockUserId2 = Guid.NewGuid();


			this.db = db;
			this.customersInMemory = new List<Customer> {
				new Customer { CustomerId = Guid.NewGuid(), CustomerName = "Customer A1", UserId = mockUserId1 },
				new Customer { CustomerId = Guid.NewGuid(), CustomerName = "Customer B1", UserId = mockUserId1 },
				new Customer { CustomerId = Guid.NewGuid(), CustomerName = "Customer C1", UserId = mockUserId1 },
				new Customer { CustomerId = Guid.NewGuid(), CustomerName = "Customer A2", UserId = mockUserId2 },
				new Customer { CustomerId = Guid.NewGuid(), CustomerName = "Customer B2", UserId = mockUserId2 },
				new Customer { CustomerId = Guid.NewGuid(), CustomerName = "Customer C2", UserId = mockUserId2 }
			};

		}

		public Task<IEnumerable<Customer>> GetCustomers()
		{
			return Task.FromResult(customersInMemory.Where(c => c.UserId == mockUserId1));
		}

		public Task<Customer?> GetCustomerById(Guid id)
		{
			return Task.FromResult(customersInMemory.Where(c => c.CustomerId == id).FirstOrDefault());
		}

		public Task InsertCustomer(CustomerViewModel customer)
		{
			Customer c = new Customer
			{
				CustomerId = Guid.NewGuid(),
				UserId = mockUserId1,
				CustomerName = customer.CustomerName
			};
			customersInMemory = customersInMemory.Append(c);
			return GetCustomers();


		}
	}
}
