using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Data.DomainModels
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }
        public string? CustomerName { get; set; }
    }
}
