using BudgetBuddy.constants;
using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Data.DomainModels
{
    public class Job
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Job name is too long")]
        public string? JobName { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        public IEnumerable<DirectLabor>? DirectLabors { get; set; }
        public IEnumerable<DirectMaterial>? DirectMaterials { get; set; }
        public Status CurrentStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
    }
}
