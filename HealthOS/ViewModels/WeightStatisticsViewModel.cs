using System.Collections.Generic;
using HealthOS.Models.Statistics;

namespace HealthOS.Models.ViewModels
{
    public class WeightStatisticsViewModel
    {
        public List<WeightStatistics> WeightStatistics { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string MonthName { get; set; }
        public string ChartDataPoints { get; set; }
        public int PageNumber { get; set; }
    }
}
