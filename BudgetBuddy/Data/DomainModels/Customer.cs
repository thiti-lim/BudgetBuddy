using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Data.DomainModels
{
    public class Customer
    {
        public int Id { get; set; }
        public string UserId { get; set; }
		[Required]
        [StringLength(50, ErrorMessage = "Customer name is too long")]
        public string? CustomerName { get; set; }
    }
}
