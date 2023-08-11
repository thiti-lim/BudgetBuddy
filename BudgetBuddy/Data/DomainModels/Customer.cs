using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Data.DomainModels
{
    public class Customer
    {
        public Guid UserId { get; set; }
        public string? CustomerName { get; set; }
    }
}
