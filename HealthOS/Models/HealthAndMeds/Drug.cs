using System.ComponentModel.DataAnnotations;

namespace HealthOS.Models
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string ConsumptionMethod { get; set; } // sposób dawkowania tj 'o 8 po śniadaniu', 'o 9 i 20' etc
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