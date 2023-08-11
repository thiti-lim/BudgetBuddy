using BudgetBuddy.Data.DomainModels;
using BudgetBuddy.ViewModels;

namespace BudgetBuddy.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task InsertCustomer(CustomerViewModel customer);
    }
}