namespace BudgetBuddy.Data.DomainModels
{
    public class DirectLabor
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string? LaborName { get; set; }
        public decimal ExpectedWage { get; set; }
        public decimal ExpectedHours  { get; set; }
        public decimal ActualWage { get; set; }
        public decimal ActualMinutes  { get; set; }
    }
}
