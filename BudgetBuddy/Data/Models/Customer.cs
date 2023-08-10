using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Data.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Guid User { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
    }
}
