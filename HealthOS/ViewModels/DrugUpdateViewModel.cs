namespace HealthOS.Models
{
    public class DrugUpdateViewModel
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public string ConsumptionMethod { get; set; }
        #region time of consumption (days)
        public bool Day1 { get; set; }
        public bool Day2 { get; set; }
        public bool Day3 { get; set; }
        public bool Day4 { get; set; }
        public bool Day5 { get; set; }
        public bool Day6 { get; set; }
        public bool Day7 { get; set; }
        #endregion
    }
}