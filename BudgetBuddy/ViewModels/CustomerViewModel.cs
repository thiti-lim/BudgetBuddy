using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Customer name is too long")]
        public string CustomerName { get; set; } = String.Empty; 
    }
}
