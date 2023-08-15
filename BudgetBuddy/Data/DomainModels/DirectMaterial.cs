namespace BudgetBuddy.Data.DomainModels
{
    public class DirectMaterial
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public string? MaterialName { get; set; }
        public decimal ExpectedCost { get; set; }
        public decimal ExpectedUnits  { get; set; }
        public decimal ActualCost { get; set; }
        public decimal ActualUnits  { get; set; }
    }
}
